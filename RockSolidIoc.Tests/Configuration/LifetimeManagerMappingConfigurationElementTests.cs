using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class LifetimeManagerMappingConfigurationElementTests
  {
    [TestMethod]
    public void TestTypeName()
    {
      string s = "typeName";
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      element.TypeName = s;
      Assert.AreEqual(s, element.TypeName);
    }

    [TestMethod]
    public void TestLifetimeManagerTypeName()
    {
      string s = "lifetimeManager";
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      element.LifetimeManagerTypeName = s;
      Assert.AreEqual(s, element.LifetimeManagerTypeName);
    }

    [TestMethod]
    public void TestName()
    {
      string s = "name";
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      element.Name = s;
      Assert.AreEqual(s, element.Name);
    }
  }

}