using System;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using EPICCentral.REST.v0100.Logging;
using EPICCentral.REST.v0100.Scanning;
using EPICCentralDL.Linq;
using EPICCentralServiceAPI.REST.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class WSEventTest
    {
        [TestMethod]
        public void Web_Service_For_Reporting_Status()
        {
            // pick a device to test
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.ScansAvailable > 0);
            Assert.IsNotNull(device);

            // setup service call
            var output = new StringWriter();
            var service = new EventService();
            var url = new Uri("http://localhost/" + service.GetProperties().Url + "/add", UriKind.Absolute);
            HttpContext.Current = new HttpContext(
                new HttpRequest(url.AbsolutePath, url.AbsoluteUri, url.Query),
                new HttpResponse(output));
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(device.UniqueIdentifier));
            Thread.CurrentPrincipal = HttpContext.Current.User;

            //report a new event
            var eventTime = DateTime.UtcNow;
            service.Create(new Event
                               {
                                   Time = eventTime,
                                   Type = EventType.Ping
                               });

            // check the latest event is a ping
            var deviceEvent = new LinqMetaData().DeviceEvent.FirstOrDefault(x => x.EventTime == eventTime);
            Assert.IsNotNull(deviceEvent);
        }
    }
}
