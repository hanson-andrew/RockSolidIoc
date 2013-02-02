using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockSolidIoc.Tests
{
  [TestClass()]
  public class IocDependencyAttributeTests
  {
    [TestMethod()]
    public void TestIdentifier()
    {
      string identifier1 = "identifier1";
      IocDependencyAttribute testAttribute = new IocDependencyAttribute(identifier1);
      Assert.AreEqual(identifier1, testAttribute.Identifier);
      string identifier2 = "identifier2";
      testAttribute.Identifier = identifier2;
      Assert.AreEqual(identifier2, testAttribute.Identifier);
    }

    [TestMethod()]
    public void TestEmptyIdentifier()
    {
      IocDependencyAttribute testAttribute = new IocDependencyAttribute();
      Assert.AreEqual(String.Empty, testAttribute.Identifier);
    }
  }

}