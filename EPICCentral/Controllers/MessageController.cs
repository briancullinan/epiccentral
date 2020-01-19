using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using ControllerRes;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Filters;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Controls all device messaging functionality.  Messages can be sent to ClearView and displayed in the alert area.
    /// </summary>
    public class MessageController : DataTablesController
    {
        //
        // GET: /Message/
        [Allow(Roles = "Service Administrator")]
        [ActionMenu(Rank = 1000, ResourceName = "MessageList_Messages")]
        public ActionResult List([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            var result = View(new LinqMetaData().Message);

            if (dtRequestModel == null)
                return result;

            return Query(result, dtRequestModel);
        }

        [Allow(Roles = "Service Administrator")]
        public ActionResult Edit(long messageId)
        {
            var message = new MessageEntity(messageId);
            if(message.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Message);

            return PartialView(new ComposeMessage(message));
        }

        [HttpPost]
        [Allow(Roles = "Service Administrator")]
        public ActionResult Edit(long messageId, ComposeMessage model)
        {
            var message = new MessageEntity(messageId);
            if (message.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Message);

            if (ModelState.IsValid)
            {
                var transaction = new Transaction(IsolationLevel.ReadCommitted, "edit message");
                try
                {
                    // if the device list has missing devices create a new message and remove the intersecting devices from the old message
                    // only if the message has been delivered, otherwise remove the device message normally below
                    if (message.DeviceMessages.Where(x => x.DeliveryTime != null).Select(x => x.Device).Except(model.Tos).Any())
                    {
                        // remove the devices from the old message that are included in the new model
                        foreach (var device in message.DeviceMessages.Select(x => x.Device).Intersect(model.Tos))
                        {
                            var deviceMessage = new DeviceMessageEntity(device.DeviceId, message.MessageId);
                            transaction.Add(deviceMessage);
                            deviceMessage.Delete();
                        }

                        // create a new message for the model leaving the old message Already Delivered
                        message = new MessageEntity
                                             {
                                                 MessageType = model.Type,
                                                 Title = model.Title,
                                                 Body = model.Body,
                                                 CreateTime = DateTime.UtcNow,
                                                 StartTime = model.StartTime.ToUniversalTime(),
                                                 EndTime =
                                                     model.EndTime.HasValue
                                                         ? model.EndTime.Value.ToUniversalTime()
                                                         : new DateTime?()
                                             };
                        transaction.Add(message);
                    }
                    else
                    {
                        // devices are only added to the message, none removed, so update the existing message
                        message.MessageType = model.Type;
                        message.Title = model.Title;
                        message.Body = model.Body;
                        message.CreateTime = DateTime.UtcNow;
                        message.StartTime = model.StartTime.ToUniversalTime();
                        message.EndTime =
                            model.EndTime.HasValue
                                ? model.EndTime.Value.ToUniversalTime()
                                : new DateTime?();
                        transaction.Add(message);
                    }
                    message.Save();

                    // remove any removed device IDs, 
                    //  if messages have already been delivered a new message will be created above and nothing more will be done here
                    foreach (var device in message.DeviceMessages.Select(x => x.Device).Except(model.Tos))
                    {
                        var deviceMessage = new DeviceMessageEntity(device.DeviceId, message.MessageId);
                        transaction.Add(deviceMessage);
                        deviceMessage.Delete();
                    }

                    // add the devicemessage entities for all the tos
                    foreach (var device in model.Tos)
                    {
                        var dm = new DeviceMessageEntity(device.DeviceId, message.MessageId)
                        {
                            DeviceId = device.DeviceId,
                            MessageId = message.MessageId
                        };
                        transaction.Add(dm);
                        dm.Save();
                    }

                    transaction.Commit();
                    return new EmptyResult();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new HttpException(417, Message.AddError);
                }
                finally
                {
                    transaction.Dispose();
                }
            }

            Response.StatusCode = 417;
            Response.TrySkipIisCustomErrors = true;

            return PartialView(model);
        }

        [Allow(Roles = "Service Administrator")]
        public ActionResult Add()
        {
            return PartialView("Edit", new ComposeMessage());
        }

        [HttpPost]
        [Allow(Roles = "Service Administrator")]
        public ActionResult Add(ComposeMessage model)
        {
            if (ModelState.IsValid)
            {
                var transaction = new Transaction(IsolationLevel.ReadCommitted, "add message");
                try
                {
                    // add the message
                    var message = new MessageEntity
                                      {
                                          MessageType = model.Type,
                                          Title = model.Title,
                                          Body = model.Body,
                                          CreateTime = DateTime.UtcNow,
                                          StartTime = model.StartTime.ToUniversalTime(),
                                          EndTime = model.EndTime.HasValue ? model.EndTime.Value.ToUniversalTime() : new DateTime?()
                                      };
                    transaction.Add(message);
                    message.Save();

                    // add the devicemessage entities for all the tos
                    foreach (var device in model.Tos)
                    {
                        var dm = new DeviceMessageEntity
                                     {
                                         DeviceId = device.DeviceId,
                                         MessageId = message.MessageId
                                     };
                        transaction.Add(dm);
                        dm.Save();
                    }

                    transaction.Commit();

                    return new EmptyResult();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new HttpException(417, Message.AddError);
                }
                finally
                {
                    transaction.Dispose();
                }
            }

            Response.StatusCode = 417;
            Response.TrySkipIisCustomErrors = true;

            return PartialView("Edit", model);
        }

        /// <summary>
        /// Filters out the To addresses based on user permissions and the search term typed in by the user.
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        private IEnumerable<dynamic> GetTosInternal(string term)
        {
            // loop through all entities and filter based on the type and if it contains the term.
            foreach (var recipient in ComposeMessage.Entities)
            {
                var device = recipient as DeviceEntity;
                if(device != null)
                {
                    var label = String.Format(Message.DeviceFormat, SharedRes.Formats.Device.FormatWith(device));
                    if(label.IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                        yield return new
                        {
                            value = MessageValidationAttribute.GetId(device), 
                            label
                        };
                }
                var location = recipient as LocationEntity;
                if (location != null && location.Name.IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                    yield return new
                    {
                        value = MessageValidationAttribute.GetId(location),
                        label = String.Format(Message.LocationFormat, location.Name)
                    };
                var organization = recipient as OrganizationEntity;
                if (organization != null && organization.Name.IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                    yield return new
                    {
                        value = MessageValidationAttribute.GetId(organization),
                        label = String.Format(Message.OrganizationFormat, organization.Name)
                    };
            }
        }

        /// <summary>
        /// AJAX callback for the jQuery autocomplete function.
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [Allow(Roles = "Service Administrator")]
        public ActionResult GetTos(string term)
        {
            return Json(GetTosInternal(term), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Sets the message to inactive so it will not be received by any more devices.
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public ActionResult Remove(long messageId)
        {
            var message = new MessageEntity(messageId);
            if (message.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Message);

            message.IsActive = false;
            message.Save();
            return new EmptyResult();
        }
    }
}
