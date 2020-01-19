using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;

namespace EPICCentral.REST.Core
{
	public static class ServiceRegistrar
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Service));

		private const string URLROOT = "/api/";
		private static readonly SortedDictionary<string, ServiceRecord> Services; 

		static ServiceRegistrar()
		{
			Log.Info("Initializing ...");

			Services = new SortedDictionary<string, ServiceRecord>(new PathComparer());
			foreach (Type type in Assembly.GetAssembly(typeof(ServiceRegistrar)).GetTypes())
			{
				if (typeof(Service).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
				{
					ConstructorInfo constructorInfo = type.GetConstructor(new Type[] {});
					if (constructorInfo != null)
					{
						Service service = (Service)constructorInfo.Invoke(new object[] {});
						Service.ServiceProperties properties = service.GetProperties();
						Register(service.GetType(), properties.Version, properties.Url, properties.MaxReceivedMessageSize);
					}
				}
			}
		}

		public static string ServiceUrlRoot { get { return URLROOT; } }

		public static IEnumerable<ServiceRecord> GetServiceRecords()
		{
			return Services.Values;
		}

		public static ServiceRecord GetServiceRecord(string url)
		{
			if (Services.Count > 0)
			{
				foreach (string key in Services.Keys)
				{
					if (key.Length <= url.Length)
					{
						int c = String.Compare(key, 0, url, 0, key.Length, StringComparison.OrdinalIgnoreCase);
						if (c == 0)
							return Services[key];
						if (c > 0)
							return null;
					}
				}
			}

			return null;
		}

		private static void Register(Type serviceType, string version, string url, int maxMessageSize)
		{
			Log.Info(string.Format("Registering service: {0}, version: {1}, url: {2}, maxMessageSize: {3}", serviceType, version, url, maxMessageSize));

			ServiceRecord service = new ServiceRecord(serviceType, version, url, maxMessageSize);
			Services.Add(service.GetServiceUrl(URLROOT), service);
		}

		private class PathComparer : IComparer<string>
		{
			public int Compare(string x, string y)
			{
				if (x.Length > y.Length)
				{
					int c = String.Compare(x, 0, y, 0, y.Length, StringComparison.OrdinalIgnoreCase);
					return c == 0 ? -1 : c;
				}
				
				if (x.Length < y.Length)
				{
					int c = String.Compare(x, 0, y, 0, x.Length, StringComparison.OrdinalIgnoreCase);
					return c == 0 ? 1 : c;
				}

				return String.Compare(x, y, StringComparison.OrdinalIgnoreCase);
			}
		}
	}

	public class ServiceRecord
	{
		public ServiceRecord(Type serviceType, string version, string url, int maxMessageSize)
		{
			ServiceType = serviceType;
			Version = version;
			Url = url;
			MaxReceivedMessageSize = maxMessageSize;
		}

		public Type ServiceType { get; private set; }
		public string Version { get; private set; }
		public string Url { get; private set; }
		public int MaxReceivedMessageSize { get; private set; }

		public string GetServiceUrl(string prefix)
		{
			return string.Format("{0}/{1}/{2}", prefix.Trim().TrimEnd(new[] {'/'}), Version, Url.Trim().Trim(new[] {'/'}));
		}
	}
}