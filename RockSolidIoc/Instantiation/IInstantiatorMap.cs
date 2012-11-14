using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public interface IInstantiatorMap : ITupleMap<Type, string, object>
  {

  }
}