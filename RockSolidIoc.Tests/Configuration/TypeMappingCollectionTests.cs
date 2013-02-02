using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class TypeMappingCollectionTests
  {
    [TestMethod]
    public void TestIsNotReadOnly()
    {
      TypeMappingCollection collection = new TypeMappingCollection();
      Assert.IsFalse(collection.IsReadOnly());
    }

    [TestMethod]
    public void TestAdd()
    {
      TypeMappingCollection collection = new TypeMappingCollection();
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      collection.Add(element);
      TypeMappingConfigurationElement[] returnedElements = new TypeMappingConfigurationElement[1];
      collection.CopyTo(returnedElements, 0);
      Assert.AreEqual(element, returnedElements[0]);
    }
  }

}