using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class TypeMappingConfigurationElementTests
  {
    [Fact()]
    public void TestTypeName()
    {
      string s = "typeName";
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      element.TypeName = s;
      Assert.Equal(s, element.TypeName);
    }

    [Fact()]
    public void TestMapTo()
    {
      string s = "mapTo";
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      element.MapTo = s;
      Assert.Equal(s, element.MapTo);
    }

    [Fact()]
    public void TestName()
    {
      string s = "name";
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      element.Name = s;
      Assert.Equal(s, element.Name);
    }

  }

}