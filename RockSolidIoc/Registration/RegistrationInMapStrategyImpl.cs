using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class RegistrationInMapStrategyImpl : PickRegistrationStrategy
  {

    public override object PickRegistration(IRegistrationMap registrationMap, Type type, string identifier)
    {
      if (registrationMap.IsInMap(type, identifier))
      {
        return registrationMap.GetMappedObject(type, identifier);
      }
      else if (this.NextStep != null)
      {
        return this.NextStep.PickRegistration(registrationMap, type, identifier);
      }
      return null;
    }
  }
}