using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  public abstract class FindLifetimeManagerStrategy : Strategy<FindLifetimeManagerStrategy>
  {

    public abstract object FindLifetimeManager(ILifetimeManagerMap map, Type type, string identifier);

  }

}