using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ResolverConfigurationElementTests
  {
    [TestMethod]
    public void TestTypeName()
    {
      string s = "typeName";
      ResolverConfigurationElement element = new ResolverConfigurationElement();
      element.TypeName = s;
      Assert.AreEqual(s, element.TypeName);
    }

    [TestMethod]
    public void TestResolverTypeName()
    {
      string s = "resolverType";
      ResolverConfigurationElement element = new ResolverConfigurationElement();
      element.ResolverTypeName = s;
      Assert.AreEqual(s, element.ResolverTypeName);
    }

    [TestMethod]
    public void TestName()
    {
      string s = "name";
      ResolverConfigurationElement element = new ResolverConfigurationElement();
      element.Name = s;
      Assert.AreEqual(s, element.Name);
    }
  }

}