using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public abstract class FindInstantiatorStrategy : Strategy<FindInstantiatorStrategy>
  {

    public abstract object FindInstantiator(IInstantiatorMap map, Type type, string identifier);

  }
}