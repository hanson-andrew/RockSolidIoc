using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace RockSolidIoc.Tests
{

  public class UseLifetimeManagerAttributeTests
  {
    [Fact()]
    public void TestTypeOnlyConstructor()
    {
      Type mappedType = typeof(string);
      UseLifetimeManagerAttribute testAttribute = new UseLifetimeManagerAttribute(mappedType);
      Assert.Equal(mappedType, testAttribute.Type);
      Assert.Equal(String.Empty, testAttribute.Identifier);
    }

    [Fact()]
    public void TestTypeStringConstructor()
    {
      Type mappedType = typeof(string);
      string identifier = "identifier";
      UseLifetimeManagerAttribute testAttribute = new UseLifetimeManagerAttribute(mappedType, identifier);
      Assert.Equal(mappedType, testAttribute.Type);
      Assert.Equal(identifier, testAttribute.Identifier);
    }
  }

}