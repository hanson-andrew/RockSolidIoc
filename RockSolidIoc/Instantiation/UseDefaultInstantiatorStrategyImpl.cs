using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class UseDefaultInstantiatorStrategyImpl : FindInstantiatorStrategy
  {

    public override object FindInstantiator(IInstantiatorMap map, Type type, string identifier)
    {
      return new DefaultInstantiator();
    }

  }
}