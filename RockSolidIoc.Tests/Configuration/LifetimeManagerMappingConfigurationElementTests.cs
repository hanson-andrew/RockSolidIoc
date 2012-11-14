using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class LifetimeManagerMappingConfigurationElementTests
  {
    [Fact()]
    public void TestTypeName()
    {
      string s = "typeName";
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      element.TypeName = s;
      Assert.Equal(s, element.TypeName);
    }

    [Fact()]
    public void TestLifetimeManagerTypeName()
    {
      string s = "lifetimeManager";
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      element.LifetimeManagerTypeName = s;
      Assert.Equal(s, element.LifetimeManagerTypeName);
    }

    [Fact()]
    public void TestName()
    {
      string s = "name";
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      element.Name = s;
      Assert.Equal(s, element.Name);
    }
  }

}