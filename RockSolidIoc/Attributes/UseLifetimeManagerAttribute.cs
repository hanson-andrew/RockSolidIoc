using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public sealed class UseLifetimeManagerAttribute : Attribute
  {

    public Type Type { get; private set; }
    public string Identifier { get; private set; }

    public UseLifetimeManagerAttribute(Type type) : this(type, string.Empty) { }

    public UseLifetimeManagerAttribute(Type type, string identifier)
    {
      this.Type = type;
      this.Identifier = identifier;
    }

  }

}