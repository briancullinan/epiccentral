using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPICCentralServiceAPI.REST.Objects
{
	public class Location
	{
		public string UniqueIdentifier { get; set; }
		public string Name { get; set; }
	}

	[CollectionDataContract]
	public class Locations : List<Location>
	{
		public Locations()
		{ }

		public Locations(IEnumerable<Location> locations)
			: base(locations)
		{ }
	}
}
