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
			BaseAdd(resolver);
		}

		protected override System.Configuration.ConfigurationElement CreateNewElement()
		{
			return new LifetimeManagerMappingConfigurationElement();
		}

		protected override object GetElementKey(System.Configuration.ConfigurationElement element)
		{
			LifetimeManagerMappingConfigurationElement typedElement = (LifetimeManagerMappingConfigurationElement)element;
			string typeName = typedElement.TypeName;
			string lifetimeManagerTypeName = typedElement.LifetimeManagerTypeName;
			string identifier = typedElement.Name;
			if (string.IsNullOrEmpty(identifier)) {
				identifier = string.Empty;
			}
			return typeName + lifetimeManagerTypeName + identifier;
		}
	}

}
