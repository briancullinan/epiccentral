using System;

namespace MvcApi
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public class ApiBind : Attribute
	{
	}
}
