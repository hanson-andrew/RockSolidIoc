using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class LifetimeManagerCollectionTests
  {
    [Fact()]
    public void TestIsNotReadOnly()
    {
      LifetimeManagerMappingCollection collection = new LifetimeManagerMappingCollection();
      Assert.False(collection.IsReadOnly());
    }

    [Fact()]
    public void TestAdd()
    {
      LifetimeManagerMappingCollection collection = new LifetimeManagerMappingCollection();
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      collection.Add(element);
      LifetimeManagerMappingConfigurationElement[] returnedElements = new LifetimeManagerMappingConfigurationElement[1];
      collection.CopyTo(returnedElements, 0);
      Assert.Equal(element, returnedElements[0]);
    }
  }

}
