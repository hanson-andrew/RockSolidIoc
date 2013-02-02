using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ConfigurationSectionHelperTests
  {
    [TestMethod]
    public void TestResolvers()
    {
      ResolverCollection resolvers = new ResolverCollection();
      ConfigurationSectionHelper testHelper = new ConfigurationSectionHelper();
      testHelper.Resolvers = resolvers;
      Assert.AreEqual(resolvers, testHelper.Resolvers);
    }

    [TestMethod]
    public void TestLifetimeManagerMappings()
    {
      LifetimeManagerMappingCollection mappings = new LifetimeManagerMappingCollection();
      ConfigurationSectionHelper testHelper = new ConfigurationSectionHelper();
      testHelper.LifetimeManagerMappings = mappings;
      Assert.AreEqual(mappings, testHelper.LifetimeManagerMappings);
    }

    [TestMethod]
    public void TestTypeMappings()
    {
      TypeMappingCollection mappings = new TypeMappingCollection();
      ConfigurationSectionHelper testHelper = new ConfigurationSectionHelper();
      testHelper.TypeMappings = mappings;
      Assert.AreEqual(mappings, testHelper.TypeMappings);
    }
  }

}