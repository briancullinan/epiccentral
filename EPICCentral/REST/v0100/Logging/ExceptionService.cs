extern alias CurrentAPI;

using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EPICCentral.Controllers;
using EPICCentralDL.EntityClasses;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;	// Map alias in DLL reference to an import alias.

namespace EPICCentral.REST.v0100.Logging
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class ExceptionService : VersionService
	{
		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "exceptions" };
		}

		// NOT CURRENTLY USED.
		[WebGet(UriTemplate = "{id}")]
		public V0100.Objects.ExceptionLog Get(string id)
		{
			DeviceEntity device = GetDevice();

			ExceptionLogEntity exceptionLog = GetException(id);

			if (exceptionLog.DeviceId != device.DeviceId)
				throw new WebFaultException<string>("Access to resource denied", HttpStatusCode.Forbidden);

			return new V0100.Objects.ExceptionLog
					{
					       	ExceptionLogId = exceptionLog.ExceptionLogId,
					       	DeviceId = exceptionLog.DeviceId,
					       	RemoteExceptionLogId = exceptionLog.RemoteExceptionLogId,
					       	Title = exceptionLog.Title,
					       	Message = exceptionLog.Message,
					       	StackTrace = exceptionLog.StackTrace,
					       	LogTime = exceptionLog.LogTime,
					       	User = exceptionLog.User,
					       	FormName = exceptionLog.FormName,
					       	MachineName = exceptionLog.MachineName,
					       	MachineOS = exceptionLog.MachineOS,
					       	ApplicationVersion = exceptionLog.ApplicationVersion,
					       	CLRVersion = exceptionLog.CLRVersion,
					       	MemoryUsage = exceptionLog.MemoryUsage,
					       	ReceivedTime = exceptionLog.ReceivedTime
					};
		}

		[WebInvoke(UriTemplate = "", Method = "POST")]
		public V0100.Objects.ExceptionLog Create(V0100.Objects.ExceptionLog exceptionLog)
		{
			DeviceEntity device = GetDevice();

			ExceptionLogEntity log = new ExceptionLogEntity
			                         	{
												DeviceId = device.DeviceId,
			                         			RemoteExceptionLogId = exceptionLog.RemoteExceptionLogId,
			                         			Title = exceptionLog.Title,
			                         			Message = exceptionLog.Message,
			                         			StackTrace = exceptionLog.StackTrace,
			                         			LogTime = exceptionLog.LogTime,
			                         			User = exceptionLog.User,
			                         			FormName = exceptionLog.FormName,
			                         			MachineName = exceptionLog.MachineName,
			                         			MachineOS = exceptionLog.MachineOS,
			                         			ApplicationVersion = exceptionLog.ApplicationVersion,
			                         			CLRVersion = exceptionLog.CLRVersion,
			                         			MemoryUsage = exceptionLog.MemoryUsage,
                                                ReceivedTime = DateTime.UtcNow
			                         	};
			log.Save();

			exceptionLog.ExceptionLogId = log.ExceptionLogId;
			exceptionLog.ReceivedTime = log.ReceivedTime;

            OperationController.Update();

			return exceptionLog;
		}

		private static ExceptionLogEntity GetException(string id)
		{
			long exceptionId;

			if (long.TryParse(id, out exceptionId))
			{
				ExceptionLogEntity exceptionLog = new ExceptionLogEntity(exceptionId);
				if (!exceptionLog.IsNew)
					return exceptionLog;

				throw new WebFaultException<string>("Item not found", HttpStatusCode.NotFound);
			}

			throw new WebFaultException<string>("Input id must be integer", HttpStatusCode.BadRequest);
		}
	}
}