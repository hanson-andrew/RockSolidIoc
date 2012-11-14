using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  class ResolverImpl2 : IInstantiator
  {
    public object ResolveDependency(Type type, IIocContainer context)
    {
      throw new NotImplementedException();
    }
  }

}