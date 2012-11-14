using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = true)]
  public sealed class MapToAttribute : Attribute
  {
    public Type MappedType { get; private set; }
    public string Identifier { get; private set; }

    public MapToAttribute(Type mappedType) : this(mappedType, string.Empty) { }

    public MapToAttribute(Type mappedType, string identifier)
    {
      this.MappedType = mappedType;
      this.Identifier = identifier;
    }

  }

}