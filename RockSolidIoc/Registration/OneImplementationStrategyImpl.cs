using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  public class OneImplementationStrategyImpl : PickRegistrationStrategy
  {

    public override object PickRegistration(IRegistrationMap registrationMap, Type type, string identifier)
    {
      if (type.IsInterface)
      {

        Type[] implementingTypes = AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(s => s.GetTypes()).Where(prop => !prop.Equals(type) && type.IsAssignableFrom(prop)).ToArray();
        if (implementingTypes.Count() == 1)
        {
          return implementingTypes.First();
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