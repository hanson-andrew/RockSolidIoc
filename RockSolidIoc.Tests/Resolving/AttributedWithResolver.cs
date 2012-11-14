using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  [UseIInstantiator(typeof(ResolverImpl1))]
  [UseIInstantiator(typeof(ResolverImpl2), "2")]
  public class AttributedWithResolver
  {
  }

}