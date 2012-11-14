using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace RockSolidIoc.Tests
{

  public class MapToAttributeTests
  {
    [Fact()]
    public void TestTypeOnlyConstructor()
    {
      Type mappedType = typeof(string);
      MapToAttribute testAttribute = new MapToAttribute(mappedType);
      Assert.Equal(mappedType, testAttribute.MappedType);
      Assert.Equal(String.Empty, testAttribute.Identifier);
    }

    [Fact()]
    public void TestTypeStringConstructor()
    {
      Type mappedType = typeof(string);
      string identifier = "identifier";
      MapToAttribute testAttribute = new MapToAttribute(mappedType, identifier);
      Assert.Equal(mappedType, testAttribute.MappedType);
      Assert.Equal(identifier, testAttribute.Identifier);
    }
  }

}
