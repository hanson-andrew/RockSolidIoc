using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  [UseLifetimeManager(typeof(ContainerManagedLifetimeManager))]
  [UseLifetimeManager(typeof(ExternallyControlledLifetimeManager), "weak")]
  public class AttributedWithLifetimeManager
  {
  }

}