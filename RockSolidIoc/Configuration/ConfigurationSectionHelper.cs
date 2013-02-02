using System.Configuration;

namespace RockSolidIoc
{

	public class ConfigurationSectionHelper : ConfigurationSection
	{

		[ConfigurationProperty("resolvers")]
		public virtual ResolverCollection Resolvers {
			get { return (ResolverCollection)this["resolvers"]; }
			set { this["resolvers"] = value; }
		}

		[ConfigurationProperty("lifetime-manager-mappings")]
		public virtual LifetimeManagerMappingCollection LifetimeManagerMappings {
			get { return (LifetimeManagerMappingCollection)this["lifetime-manager-mappings"]; }
			set { this["lifetime-manager-mappings"] = value; }
		}

		[ConfigurationProperty("type-mappings")]
		public virtual TypeMappingCollection TypeMappings {
			get { return (TypeMappingCollection)this["type-mappings"]; }
			set { this["type-mappings"] = value; }
		}

	}

}
