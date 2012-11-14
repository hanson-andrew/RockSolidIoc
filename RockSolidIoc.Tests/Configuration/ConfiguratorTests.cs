using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;
using System.Diagnostics;

namespace RockSolidIoc.Tests
{

  public class ConfiguratorTests
  {
    [Fact()]
    public void TestParsingResolvers()
    {
      ConfigurationSectionHelper helper = new ConfigurationSectionHelper();
      ResolverConfigurationElement resolver = new ResolverConfigurationElement();
      resolver.ResolverTypeName = "RockSolidIoc.Tests.MockFriendlyResolver";
      resolver.TypeName = "System.String";
      ResolverCollection collection = new ResolverCollection();
      collection.Add(resolver);
      helper.Resolvers = collection;
      Configurator testConfigurator = new Configurator();
      IIocContainer result = testConfigurator.Configure(helper);
      string s = result.Resolve<string>();
      MockFriendlyResolver.Mock.Verify(p => p.ResolveDependency(typeof(string), result), Times.Exactly(1));
      MockFriendlyResolver.ResetMock();
    }

    [Fact()]
    public void TestParsingLifetimeManager()
    {
      ConfigurationSectionHelper helper = new ConfigurationSectionHelper();
      LifetimeManagerMappingConfigurationElement element = new LifetimeManagerMappingConfigurationElement();
      element.LifetimeManagerTypeName = "RockSolidIoc.Tests.MockFriendlyLifetimeManager";
      element.TypeName = "System.Object";
      LifetimeManagerMappingCollection collection = new LifetimeManagerMappingCollection();
      collection.Add(element);
      helper.LifetimeManagerMappings = collection;
      Configurator testConfigurator = new Configurator();
      IIocContainer result = testConfigurator.Configure(helper);
      object s = result.Resolve<object>();
      MockFriendlyLifetimeManager.Mock.Verify(p => p.AddInstance(It.IsAny<object>()), Times.Exactly(1));
      MockFriendlyLifetimeManager.ResetMock();
    }

    [Fact()]
    public void TestParsingRegistrations()
    {
      ConfigurationSectionHelper helper = new ConfigurationSectionHelper();
      TypeMappingConfigurationElement element = new TypeMappingConfigurationElement();
      element.TypeName = "System.Object";
      element.MapTo = "RockSolidIoc.Tests.EmptyObject";
      TypeMappingCollection collection = new TypeMappingCollection();
      collection.Add(element);
      helper.TypeMappings = collection;
      Configurator testConfigurator = new Configurator();
      IIocContainer result = testConfigurator.Configure(helper);
      object s = result.Resolve<object>();
      Assert.IsType<EmptyObject>(s);
    }
  }

}