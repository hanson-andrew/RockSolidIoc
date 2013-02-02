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
			BaseAdd(resolver);
		}

		protected override System.Configuration.ConfigurationElement CreateNewElement()
		{
			return new TypeMappingConfigurationElement();
		}

		protected override object GetElementKey(System.Configuration.ConfigurationElement element)
		{
			TypeMappingConfigurationElement typedElement = (TypeMappingConfigurationElement)element;
			string typeName = typedElement.TypeName;
			string mapTo = typedElement.MapTo;
			string identifier = typedElement.Name;
			if (string.IsNullOrEmpty(identifier)) {
				identifier = string.Empty;
			}
			return typeName + mapTo + identifier;
		}
	}

}
