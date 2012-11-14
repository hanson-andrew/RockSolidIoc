using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Security.Permissions;

namespace RockSolidIoc
{
  [Serializable()]
  public class IocException : Exception
  {

    public IocException() : base() { }

    public IocException(string message) : base(message) { }

    public IocException(string message, Exception innerException) : base(message, innerException) { }

  }
}