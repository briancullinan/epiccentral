using System;
using System.Net;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	public class Prototype : Service
	{
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "logging/");
			}
		}

		public LogItem Get(int id)
		{
			return Invoke<LogItem>("GET", id.ToString());
		}

		public LogItems GetList(int count)
		{
			return Invoke<LogItems>("GET", "count=" + count);
		}

		public int Add(LogItem item)
		{
			item = Invoke<LogItem, LogItem>("POST", "/", item);
			return item.Id;
		}

		public void Delete(int id)
		{
			Invoke("DELETE", id.ToString());
		}
	}
}
