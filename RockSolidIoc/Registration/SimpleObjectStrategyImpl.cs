using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class SimpleObjectStrategyImpl : PickRegistrationStrategy
  {

    public override object PickRegistration(IRegistrationMap registrationMap, Type type, string identifier)
    {
      if (!type.IsAbstract && !type.IsInterface && !type.IsValueType)
      {
        return type;
      }
      else if (this.NextStep != null)
      {
        return this.NextStep.PickRegistration(registrationMap, type, identifier);
      }
      return null;
    }
  }
}