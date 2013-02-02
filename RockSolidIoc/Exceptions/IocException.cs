using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace RockSolidIoc
{

	[Serializable()]
	public class IocException : Exception
	{

		public IocException() : base()
		{
		}

		public IocException(string message) : base(message)
		{
		}

		public IocException(string message, Exception innerException) : base(message, innerException)
		{
		}

	}

}
