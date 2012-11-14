using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class InstantiatorInMapStrategyImpl : FindInstantiatorStrategy
  {

    public override object FindInstantiator(IInstantiatorMap map, Type type, string identifier)
    {
      if (map.IsInMap(type, identifier))
      {
        return map.GetMappedObject(type, identifier);
      }
      else if (map.IsInMap(type, string.Empty))
      {
        return map.GetMappedObject(type, string.Empty);
      }
      else if (this.NextStep != null)
      {
        return this.NextStep.FindInstantiator(map, type, identifier);
      }
      return null;
    }

  }
}