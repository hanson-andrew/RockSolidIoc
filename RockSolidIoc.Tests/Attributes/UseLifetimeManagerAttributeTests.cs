using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockSolidIoc.Tests
{
  [TestClass()]
  public class UseLifetimeManagerAttributeTests
  {
    [TestMethod()]
    public void TestTypeOnlyConstructor()
    {
      Type mappedType = typeof(string);
      UseLifetimeManagerAttribute testAttribute = new UseLifetimeManagerAttribute(mappedType);
      Assert.AreEqual(mappedType, testAttribute.Type);
      Assert.AreEqual(String.Empty, testAttribute.Identifier);
    }

    [TestMethod()]
    public void TestTypeStringConstructor()
    {
      Type mappedType = typeof(string);
      string identifier = "identifier";
      UseLifetimeManagerAttribute testAttribute = new UseLifetimeManagerAttribute(mappedType, identifier);
      Assert.AreEqual(mappedType, testAttribute.Type);
      Assert.AreEqual(identifier, testAttribute.Identifier);
    }
  }

}