using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;


namespace RockSolidIoc
{
  [ConfigurationCollection(typeof(TypeMappingConfigurationElement), AddItemName = "type-mapping")]
  public class TypeMappingCollection : ConfigurationElementCollection
  {

    public override bool IsReadOnly()
    {
      return false;
    }

    public void Add(TypeMappingConfigurationElement resolver)
    {
      base.BaseAdd(resolver);
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new TypeMappingConfigurationElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      TypeMappingConfigurationElement typedElement = (element as TypeMappingConfigurationElement);
      string typeName = typedElement.TypeName;
      string mapTo = typedElement.MapTo;
      string identifier = typedElement.Name;
      if (string.IsNullOrEmpty(identifier))
      {
        identifier = string.Empty;
      }
      return typeName + mapTo + identifier;
    }
  }

}