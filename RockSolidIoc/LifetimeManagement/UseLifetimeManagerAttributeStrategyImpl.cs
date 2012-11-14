using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class UseLifetimeManagerAttributeStrategyImpl : FindLifetimeManagerStrategy
  {

    public override object FindLifetimeManager(ILifetimeManagerMap map, Type type, string identifier)
    {
      object[] attributes = type.GetCustomAttributes(typeof(UseLifetimeManagerAttribute), false);

      UseLifetimeManagerAttribute defaultAttribute = null;
      UseLifetimeManagerAttribute specificAttribute = null;

      foreach (object a in attributes)
      {
        UseLifetimeManagerAttribute useAttribute = (a as UseLifetimeManagerAttribute);
        if (string.Equals(identifier, useAttribute.Identifier))
        {
          specificAttribute = useAttribute;
        }
        else if (string.IsNullOrEmpty(useAttribute.Identifier))
        {
          defaultAttribute = useAttribute;
        }
      }
      if (specificAttribute != null)
      {
        return specificAttribute;
      }
      else if (defaultAttribute != null)
      {
        return defaultAttribute;
      }
      else if (this.NextStep != null)
      {
        return this.NextStep.FindLifetimeManager(map, type, identifier);
      }
      return null;
    }

  }
}