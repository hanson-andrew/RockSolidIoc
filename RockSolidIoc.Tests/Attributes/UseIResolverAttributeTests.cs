using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace RockSolidIoc.Tests
{

  public class UseIResolverAttributeTests
  {
    [Fact()]
    public void TestTypeOnlyConstructor()
    {
      Type mappedType = typeof(string);
      UseIInstantiatorAttribute testAttribute = new UseIInstantiatorAttribute(mappedType);
      Assert.Equal(mappedType, testAttribute.Type);
      Assert.Equal(String.Empty, testAttribute.Identifier);
    }

    [Fact()]
    public void TestTypeStringConstructor()
    {
      Type mappedType = typeof(string);
      string identifier = "identifier";
      UseIInstantiatorAttribute testAttribute = new UseIInstantiatorAttribute(mappedType, identifier);
      Assert.Equal(mappedType, testAttribute.Type);
      Assert.Equal(identifier, testAttribute.Identifier);
    }
  }

}