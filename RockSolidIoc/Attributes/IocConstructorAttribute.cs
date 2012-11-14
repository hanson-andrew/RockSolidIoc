using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
  public sealed class IocConstructorAttribute : Attribute { }
}

