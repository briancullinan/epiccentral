extern alias CurrentAPI;

using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;

namespace EPICCentral.REST.v0100.Logging
{
    // Start the service and browse to http://<machine_name>:<port>/Logging/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class PrototypeService : VersionService
    {
		private static readonly List<V0100.Objects.LogItem> Items;
        private static int nextId;
        
        static PrototypeService()
        {
            nextId = 1;
            Items = new List<V0100.Objects.LogItem>();
            AddItem("Item 1", "This is item 1");
            AddItem("Item 2", "This is item 2");
            AddItem("Item 3", "This is item 3");
            AddItem("Item 4", "This is item 4");
            AddItem("Item 5", "This is item 5");
        }

		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "logging" };
		}

        [WebGet(UriTemplate = "count={count}")]
		public V0100.Objects.LogItems GetCollection(string count)
        {
            int itemCount;
            
            if (int.TryParse(count, out itemCount))
				return itemCount >= Items.Count ? new V0100.Objects.LogItems(Items) : new V0100.Objects.LogItems(Items.GetRange(0, itemCount));

            throw new WebFaultException<string>("Input parameter count must be integer", HttpStatusCode.BadRequest);
        }

        [WebGet(UriTemplate = "{id}")]
		public V0100.Objects.LogItem Get(string id)
        {
            int itemId;

            if (int.TryParse(id, out itemId))
            {
                var item = Items.Find(i => i.Id == itemId);
                if (item != null)
                    return item;

                throw new WebFaultException<string>("Item not found", HttpStatusCode.NotFound);
            }

            throw new WebFaultException<string>("Input id count must be integer", HttpStatusCode.BadRequest);
        }

        [WebInvoke(UriTemplate = "", Method = "POST")]
		public V0100.Objects.LogItem Create(V0100.Objects.LogItem item)
        {
            item.Id = AddItem(item.Name, item.Desc);
            return item;
        }

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        public void Delete(string id)
        {
            Items.Remove(Get(id));
        }

        private static int AddItem(string name, string desc)
        {
			Items.Add(new V0100.Objects.LogItem(nextId, name, desc));
            return nextId++;
        }
    }
}
