using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EPICCentralServiceAPI.REST.Objects
{
	public class LogItem
	{
		public LogItem()
		{
		}

		public LogItem(int id, string name, string desc)
		{
			Id = id;
			Name = name;
			Desc = desc;
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public string Desc { get; set; }

		public override string ToString()
		{
			return "LogItem{ Id = '" + Id + "', Name = '" + Name + "', Desc = '" + Desc + "'}";
		}
	}

	[CollectionDataContract]
	public class LogItems : List<LogItem>
	{
		public LogItems()
		{
		}

		public LogItems(IEnumerable<LogItem> logItems)
				: base(logItems)
		{
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("LogItems[ ");
			foreach (LogItem item in this)
			{
				sb.Append(item).Append(", ");
			}
			sb.Remove(sb.Length - 1, 1);
			sb.Append(" ]");
			return sb.ToString();
		}
	}
}