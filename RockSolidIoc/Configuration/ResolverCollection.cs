using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;


namespace RockSolidIoc
{
  [ConfigurationCollection(typeof(ResolverConfigurationElement), AddItemName = "resolver")]
  public class ResolverCollection : ConfigurationElementCollection
  {

    public override bool IsReadOnly()
    {
      return false;
    }

    public void Add(ResolverConfigurationElement resolver)
    {
      base.BaseAdd(resolver);
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new ResolverConfigurationElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      ResolverConfigurationElement typedElement = (element as ResolverConfigurationElement);
      string typeName = typedElement.TypeName;
      string resolverTypeName = typedElement.ResolverTypeName;
      string identifier = typedElement.Name;
      if (string.IsNullOrEmpty(identifier))
      {
        identifier = string.Empty;
      }
      return typeName + resolverTypeName + identifier;
    }

  }

}