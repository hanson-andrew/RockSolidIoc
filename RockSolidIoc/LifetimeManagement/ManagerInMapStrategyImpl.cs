using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class ManagerInMapStrategyImpl : FindLifetimeManagerStrategy
  {

    public override object FindLifetimeManager(ILifetimeManagerMap map, Type type, string identifier)
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
        return this.NextStep.FindLifetimeManager(map, type, identifier);
      }
      return null;
    }

  }
}