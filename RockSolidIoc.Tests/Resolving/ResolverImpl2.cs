using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  class ResolverImpl2 : IResolver
  {
    public object ResolveDependency(Type type, IIocContainer context)
    {
      throw new NotImplementedException();
    }
  }

}