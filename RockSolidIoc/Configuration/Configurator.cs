using System;
using System.Configuration;
using System.Reflection;

namespace RockSolidIoc
{

	public class Configurator
	{


		private const string DefaultNodePath = "JordansLibraryIoc";
		public IIocContainer Configure()
		{
			return this.Configure(DefaultNodePath);
		}

		public IIocContainer Configure(string nodePath)
		{
			ConfigurationSectionHelper config = (ConfigurationSectionHelper)ConfigurationManager.GetSection(nodePath);
			return this.Configure(config);
		}

		public IIocContainer Configure(ConfigurationSectionHelper config)
		{
			return (IIocContainer)this.GetManager(config);
		}

		private object GetManager(ConfigurationSectionHelper config)
		{
			IIocContainer container = new IocContainer();

			foreach (ResolverConfigurationElement resolverElement in config.Resolvers) {
                Type resolverType = TypeUtilities.GetType(resolverElement.ResolverTypeName);
                Type toResolveType = TypeUtilities.GetType(resolverElement.TypeName);
				string identifier = resolverElement.Name;
				container.AddResolver(resolverType, toResolveType, identifier);
			}

			foreach (LifetimeManagerMappingConfigurationElement lifetimeElement in config.LifetimeManagerMappings) {
                Type managerType = TypeUtilities.GetType(lifetimeElement.LifetimeManagerTypeName);
                Type toManageType = TypeUtilities.GetType(lifetimeElement.TypeName);
				string identifier = lifetimeElement.Name;
				container.LinkToLifetime(toManageType, managerType, identifier);
			}

			foreach (TypeMappingConfigurationElement registrationElement in config.TypeMappings) {
                Type startType = TypeUtilities.GetType(registrationElement.TypeName);
                Type mapToType = TypeUtilities.GetType(registrationElement.MapTo);
				string identifier = registrationElement.Name;
				container.RegisterType(startType, mapToType, identifier);
			}

			return container;
		}

	}

}
