namespace EPICCentralServiceAPI.REST.Objects
{
	public class Credentials
	{
		public string OrganizationUid { get; set; }
		public string LocationUid { get; set; }
		public string DeviceUid { get; set; }
		public string UidQualifier { get; set; }
		public string AuthenticationToken { get; set; }
	}
}
