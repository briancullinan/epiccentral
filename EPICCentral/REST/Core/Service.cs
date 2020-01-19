using System.Net;
using System.ServiceModel.Web;
using System.Web.Security;
using EPICCentral.Providers;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.REST.Core
{
	public abstract class Service
	{
		private UserEntity userEntity;
		private DeviceEntity deviceEntity;
		private bool isUserEntitySet;
		private bool isDeviceEntitySet;
		private MembershipUser membershipUser;

		public abstract ServiceProperties GetProperties();

		protected MembershipUser User
		{
			get { return membershipUser ?? (membershipUser = Membership.GetUser()); }
		}

		protected string Username
		{
			get
			{
				return (User is DeviceMembershipUser) ? null : User.UserName;
			}
		}

		protected int? DeviceId
		{
			get
			{
				return (User is DeviceMembershipUser) ? ((DeviceMembershipUser)User).DeviceId : (int?)null;
			}
		}

		protected UserEntity GetUser()
		{
			if (!isUserEntitySet)
			{
				isUserEntitySet = true;

				string userName = Username;
				if (userName != null)
				{
					UserCollection users = new UserCollection();
					users.GetMulti(UserFields.Username == userName);
					if (users.Count > 0)
						userEntity = users[0];
				}
			}

			// Return UserEntity. Can be null if not authenticated or user not found.
			return userEntity;
		}

		protected DeviceEntity GetDeviceEntity(ITransaction transaction)
		{
			if (!isDeviceEntitySet)
			{
				isDeviceEntitySet = true;

				int? id = DeviceId;
				if (id.HasValue)
				{
					if (transaction == null)
						deviceEntity = new DeviceEntity(id.Value);
					else
					{
						deviceEntity = new DeviceEntity();
						transaction.Add(deviceEntity);
						deviceEntity.FetchUsingPK(id.Value);
					}

					if (deviceEntity.IsNew)
						deviceEntity = null;
				}
			}

			// Return DeviceEntity. Can be null if not authenticated or device not found.
			return deviceEntity;
		}

		public class ServiceProperties
		{
			public string Version { get; set; }
			public string Url { get; set; }
			public int MaxReceivedMessageSize { get; set; }
		}
	}
}