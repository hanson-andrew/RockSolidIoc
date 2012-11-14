using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;


namespace RockSolidIoc
{
  public class ResolverConfigurationElement : ConfigurationElement
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

    [ConfigurationProperty("resolver-type")]
    public virtual string ResolverTypeName
    {
      get
      {
        return (this["resolver-type"] as string);
      }
      set
      {
        this["resolver-type"] = value;
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