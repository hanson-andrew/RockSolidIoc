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
			BaseAdd(resolver);
		}

		protected override System.Configuration.ConfigurationElement CreateNewElement()
		{
			return new ResolverConfigurationElement();
		}

		protected override object GetElementKey(System.Configuration.ConfigurationElement element)
		{
			ResolverConfigurationElement typedElement = (ResolverConfigurationElement)element;
			string typeName = typedElement.TypeName;
			string resolverTypeName = typedElement.ResolverTypeName;
			string identifier = typedElement.Name;
			if (string.IsNullOrEmpty(identifier)) {
				identifier = string.Empty;
			}
			return typeName + resolverTypeName + identifier;
		}
	}

}
