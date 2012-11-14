using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class MapToAttributeStrategyImpl : PickRegistrationStrategy
  {

    public override object PickRegistration(IRegistrationMap registrationMap, Type type, string identifier)
    {
      object[] mappingAttributes = type.GetCustomAttributes(typeof(MapToAttribute), false);
      foreach (object a in mappingAttributes)
      {
        MapToAttribute mapTo = (a as MapToAttribute);
        if (string.Equals(mapTo.Identifier, identifier))
        {
          return mapTo.MappedType;
        }
      }
      if (this.NextStep != null)
      {
        return this.NextStep.PickRegistration(registrationMap, type, identifier);
      }
      return null;
    }
  }
}