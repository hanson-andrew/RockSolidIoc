using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace RockSolidIoc
{
  public class ConfigurationSectionHelper : ConfigurationSection
  {

    [ConfigurationProperty("resolvers")]
    public virtual ResolverCollection Resolvers
    {
      get
      {
        return (this["resolvers"] as ResolverCollection);
      }
      set
      {
        this["resolvers"] = value;
      }
    }

    [ConfigurationProperty("lifetime-manager-mappings")]
    public virtual LifetimeManagerMappingCollection LifetimeManagerMappings
    {
      get
      {
        return (this["lifetime-manager-mappings"] as LifetimeManagerMappingCollection);
      }
      set
      {
        this["lifetime-manager-mappings"] = value;
      }
    }

    [ConfigurationProperty("type-mappings")]
    public virtual TypeMappingCollection TypeMappings
    {
      get
      {
        return (this["type-mappings"] as TypeMappingCollection);
      }
      set
      {
        this["type-mappings"] = value;
      }
    }

  }
}