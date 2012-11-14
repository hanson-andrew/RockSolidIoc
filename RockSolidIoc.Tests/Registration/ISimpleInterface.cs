using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  [MapTo(typeof(SimpleInterfaceImpl1))]
  [MapTo(typeof(SimpleInterfaceImpl2), "2")]
  public interface ISimpleInterface
  {
  }

}