using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class ResolverCollectionTests
  {
    [Fact()]
    public void TestIsNotReadOnly()
    {
      ResolverCollection collection = new ResolverCollection();
      Assert.False(collection.IsReadOnly());
    }

    [Fact()]
    public void TestAdd()
    {
      ResolverCollection collection = new ResolverCollection();
      ResolverConfigurationElement element = new ResolverConfigurationElement();
      collection.Add(element);
      ResolverConfigurationElement[] returnedElements = new ResolverConfigurationElement[1];
      collection.CopyTo(returnedElements, 0);
      Assert.Equal(element, returnedElements[0]);
    }
  }

}