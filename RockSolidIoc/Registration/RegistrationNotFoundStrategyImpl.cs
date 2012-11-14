using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  public class RegistrationNotFoundStrategyImpl : PickRegistrationStrategy
  {

    public override object PickRegistration(IRegistrationMap registrationMap, Type type, string identifier)
    {
      throw new IocException(string.Format("Failed to find a registration for type {0} with identifier {1}", type.FullName, identifier));
    }
  }
}