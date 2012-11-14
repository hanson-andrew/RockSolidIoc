using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class TypeMappingCollectionTests
  {
    [Fact()]
    public void TestIsNotReadOnly()
    {
      TypeMappingCollection collection = new TypeMappingCollection();
      Assert.False(collection.IsReadOnly());
    }

    [Fact()]
    public void TestAdd()
    {
      TypeMappingCollection collection = new TypeMappingCollection();
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      collection.Add(element);
      TypeMappingConfigurationElement[] returnedElements = new TypeMappingConfigurationElement[1];
      collection.CopyTo(returnedElements, 0);
      Assert.Equal(element, returnedElements[0]);
    }
  }

}