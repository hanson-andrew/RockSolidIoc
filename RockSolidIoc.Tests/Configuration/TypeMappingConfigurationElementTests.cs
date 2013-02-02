using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class TypeMappingConfigurationElementTests
  {
    [TestMethod]
    public void TestTypeName()
    {
      string s = "typeName";
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      element.TypeName = s;
      Assert.AreEqual(s, element.TypeName);
    }

    [TestMethod]
    public void TestMapTo()
    {
      string s = "mapTo";
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      element.MapTo = s;
      Assert.AreEqual(s, element.MapTo);
    }

    [TestMethod]
    public void TestName()
    {
      string s = "name";
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      element.Name = s;
      Assert.AreEqual(s, element.Name);
    }

  }

}