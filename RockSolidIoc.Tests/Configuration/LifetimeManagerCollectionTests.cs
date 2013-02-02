using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class LifetimeManagerCollectionTests
  {
    [TestMethod]
    public void TestIsNotReadOnly()
    {
      LifetimeManagerMappingCollection collection = new LifetimeManagerMappingCollection();
      Assert.IsFalse(collection.IsReadOnly());
    }

    [TestMethod]
    public void TestAdd()
    {
      LifetimeManagerMappingCollection collection = new LifetimeManagerMappingCollection();
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      collection.Add(element);
      LifetimeManagerMappingConfigurationElement[] returnedElements = new LifetimeManagerMappingConfigurationElement[1];
      collection.CopyTo(returnedElements, 0);
      Assert.AreEqual(element, returnedElements[0]);
    }
  }

}
