using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace RockSolidIoc.Tests
{

  public class IocDependencyAttributeTests
  {
    [Fact()]
    public void TestIdentifier()
    {
      string identifier1 = "identifier1";
      IocDependencyAttribute testAttribute = new IocDependencyAttribute(identifier1);
      Assert.Equal(identifier1, testAttribute.Identifier);
      string identifier2 = "identifier2";
      testAttribute.Identifier = identifier2;
      Assert.Equal(identifier2, testAttribute.Identifier);
    }

    [Fact()]
    public void TestEmptyIdentifier()
    {
      IocDependencyAttribute testAttribute = new IocDependencyAttribute();
      Assert.Equal(String.Empty, testAttribute.Identifier);
    }
  }

}