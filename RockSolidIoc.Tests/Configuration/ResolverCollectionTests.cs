using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ResolverCollectionTests
  {
    [TestMethod]
    public void TestIsNotReadOnly()
    {
      ResolverCollection collection = new ResolverCollection();
      Assert.IsFalse(collection.IsReadOnly());
    }

    [TestMethod]
    public void TestAdd()
    {
      ResolverCollection collection = new ResolverCollection();
      ResolverConfigurationElement element = new ResolverConfigurationElement();
      collection.Add(element);
      ResolverConfigurationElement[] returnedElements = new ResolverConfigurationElement[1];
      collection.CopyTo(returnedElements, 0);
      Assert.AreEqual(element, returnedElements[0]);
    }
  }

}