using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace RockSolidIoc
{
  [ConfigurationCollection(typeof(LifetimeManagerMappingConfigurationElement), AddItemName = "lifetime-manager-mapping")]
  public class LifetimeManagerMappingCollection : ConfigurationElementCollection
  {

    public override bool IsReadOnly()
    {
      return false;
    }

    public void Add(LifetimeManagerMappingConfigurationElement resolver)
    {
      base.BaseAdd(resolver);
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new LifetimeManagerMappingConfigurationElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      LifetimeManagerMappingConfigurationElement typedElement = (element as LifetimeManagerMappingConfigurationElement);
      string typeName = typedElement.TypeName;
      string lifetimeManagerTypeName = typedElement.LifetimeManagerTypeName;
      string identifier = typedElement.Name;
      if (string.IsNullOrEmpty(identifier))
      {
        identifier = string.Empty;
      }
      return typeName + lifetimeManagerTypeName + identifier;
    }
  }

}