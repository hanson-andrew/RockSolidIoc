using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace RockSolidIoc
{
  public class LifetimeManagerMappingConfigurationElement : ConfigurationElement
  {

    [ConfigurationProperty("type")]
    public virtual string TypeName
    {
      get
      {
        return (this["type"] as string);
      }
      set
      {
        this["type"] = value;
      }
    }

    [ConfigurationProperty("lifetime-manager-type")]
    public virtual string LifetimeManagerTypeName
    {
      get
      {
        return (this["lifetime-manager-type"] as string);
      }
      set
      {
        this["lifetime-manager-type"] = value;
      }
    }

    [ConfigurationProperty("name")]
    public virtual string Name
    {
      get
      {
        return (this["name"] as string);
      }
      set
      {
        this["name"] = value;
      }
    }

  }
}