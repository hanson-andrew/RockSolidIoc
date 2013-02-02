using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  [UseIResolver(typeof(ResolverImpl1))]
  [UseIResolver(typeof(ResolverImpl2), "2")]
  public class AttributedWithResolver
  {
  }

}