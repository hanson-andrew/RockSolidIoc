using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  public interface ILifetimeManagerMap : ITupleMap<Type, string, object>
  {

  }

}