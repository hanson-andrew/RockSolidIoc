using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class UseDefaultLifetimeManagerStrategyImpl : FindLifetimeManagerStrategy
  {

    public override object FindLifetimeManager(ILifetimeManagerMap map, Type type, string identifier)
    {
      return new TransientLifetimeManager();
    }

  }
}