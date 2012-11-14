using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;


namespace RockSolidIoc
{
  public class Configurator
  {

    private const string DefaultNodePath = "RockSolidIoc";

    public IIocContainer Configure()
    {
      return this.Configure(DefaultNodePath);
    }

    public IIocContainer Configure(string nodePath)
    {
      ConfigurationSectionHelper config = (ConfigurationManager.GetSection(nodePath) as ConfigurationSectionHelper);
      return this.Configure(config);
    }

    public IIocContainer Configure(ConfigurationSectionHelper config)
    {
      return this.GetManager(config);
    }

    private IIocContainer GetManager(ConfigurationSectionHelper config)
    {
      IocContainer container = new IocContainer();

      foreach (ResolverConfigurationElement resolverElement in config.Resolvers)
      {
        Type resolverType = TypeUtilities.GetType(resolverElement.ResolverTypeName);
        Type toResolveType = TypeUtilities.GetType(resolverElement.TypeName);
        string identifier = resolverElement.Name;
        container.AddInstantiator(resolverType, toResolveType, identifier);
      }

      foreach (LifetimeManagerMappingConfigurationElement lifetimeElement in config.LifetimeManagerMappings)
      {
        Type managerType = TypeUtilities.GetType(lifetimeElement.LifetimeManagerTypeName);
        Type toManageType = TypeUtilities.GetType(lifetimeElement.TypeName);
        string identifier = lifetimeElement.Name;
        container.LinkToLifetime(toManageType, managerType, identifier);
      }

      foreach (TypeMappingConfigurationElement registrationElement in config.TypeMappings)
      {
        Type startType = TypeUtilities.GetType(registrationElement.TypeName);
        Type mapToType = TypeUtilities.GetType(registrationElement.MapTo);
        string identifier = registrationElement.Name;
        container.RegisterType(startType, mapToType, identifier);
      }

      return container;
    }

  }

}