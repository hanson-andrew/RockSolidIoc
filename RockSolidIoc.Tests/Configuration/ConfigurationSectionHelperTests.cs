using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace RockSolidIoc.Tests
{

  public class ConfigurationSectionHelperTests
  {
    [Fact()]
    public void TestResolvers()
    {
      ResolverCollection resolvers = new ResolverCollection();
      ConfigurationSectionHelper testHelper = new ConfigurationSectionHelper();
      testHelper.Resolvers = resolvers;
      Assert.Equal(resolvers, testHelper.Resolvers);
    }

    [Fact()]
    public void TestLifetimeManagerMappings()
    {
      LifetimeManagerMappingCollection mappings = new LifetimeManagerMappingCollection();
      ConfigurationSectionHelper testHelper = new ConfigurationSectionHelper();
      testHelper.LifetimeManagerMappings = mappings;
      Assert.Equal(mappings, testHelper.LifetimeManagerMappings);
    }

    [Fact()]
    public void TestTypeMappings()
    {
      TypeMappingCollection mappings = new TypeMappingCollection();
      ConfigurationSectionHelper testHelper = new ConfigurationSectionHelper();
      testHelper.TypeMappings = mappings;
      Assert.Equal(mappings, testHelper.TypeMappings);
    }
  }

}