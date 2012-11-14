using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class ResolverConfigurationElementTests
  {
    [Fact()]
    public void TestTypeName()
    {
      string s = "typeName";
      ResolverConfigurationElement element = new ResolverConfigurationElement();
      element.TypeName = s;
      Assert.Equal(s, element.TypeName);
    }

    [Fact()]
    public void TestResolverTypeName()
    {
      string s = "resolverType";
      ResolverConfigurationElement element = new ResolverConfigurationElement();
      element.ResolverTypeName = s;
      Assert.Equal(s, element.ResolverTypeName);
    }

    [Fact()]
    public void TestName()
    {
      string s = "name";
      ResolverConfigurationElement element = new ResolverConfigurationElement();
      element.Name = s;
      Assert.Equal(s, element.Name);
    }
  }

}