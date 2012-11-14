using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  public class UseInstantiatorAttributeStrategyImpl : FindInstantiatorStrategy
  {

    public override object FindInstantiator(IInstantiatorMap map, Type type, string identifier)
    {
      object[] attributes = type.GetCustomAttributes(typeof(UseIInstantiatorAttribute), false);

      UseIInstantiatorAttribute defaultAttribute = null;
      UseIInstantiatorAttribute specificAttribute = null;

      foreach (object a in attributes)
      {
        UseIInstantiatorAttribute useIResolver = (a as UseIInstantiatorAttribute);
        if (string.Equals(identifier, useIResolver.Identifier))
        {
          specificAttribute = useIResolver;
        }
        else if (string.IsNullOrEmpty(useIResolver.Identifier))
        {
          defaultAttribute = useIResolver;
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
        return this.NextStep.FindInstantiator(map, type, identifier);
      }
      return null;
    }

  }
}