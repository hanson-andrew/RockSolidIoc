using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Method)]
  public sealed class IocDependencyAttribute : Attribute
  {
    public string Identifier { get; set; }

    public IocDependencyAttribute() : this(string.Empty) { }

    public IocDependencyAttribute(string identifier)
    {
      this.Identifier = identifier;
    }

  }

}