using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockSolidIoc.Tests
{
  [TestClass()]
  public class MapToAttributeTests
  {
    [TestMethod()]
    public void TestTypeOnlyConstructor()
    {
      Type mappedType = typeof(string);
      MapToAttribute testAttribute = new MapToAttribute(mappedType);
      Assert.AreEqual(mappedType, testAttribute.MappedType);
      Assert.AreEqual(String.Empty, testAttribute.Identifier);
    }

    [TestMethod()]
    public void TestTypeStringConstructor()
    {
      Type mappedType = typeof(string);
      string identifier = "identifier";
      MapToAttribute testAttribute = new MapToAttribute(mappedType, identifier);
      Assert.AreEqual(mappedType, testAttribute.MappedType);
      Assert.AreEqual(identifier, testAttribute.Identifier);
    }
  }

}
