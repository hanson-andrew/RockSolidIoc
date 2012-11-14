using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;


namespace RockSolidIoc
{
  public class TypeMappingConfigurationElement : ConfigurationElement
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

    [ConfigurationProperty("mapTo")]
    public virtual string MapTo
    {
      get
      {
        return (this["mapTo"] as string);
      }
      set
      {
        this["mapTo"] = value;
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