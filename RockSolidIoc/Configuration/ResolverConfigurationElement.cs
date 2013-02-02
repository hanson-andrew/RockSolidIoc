using System;
using System.Configuration;

namespace RockSolidIoc
{

	public class ResolverConfigurationElement : ConfigurationElement
	{

		[ConfigurationProperty("type")]
		public virtual string TypeName {
			get { return Convert.ToString(this["type"]); }
			set { this["type"] = value; }
		}

		[ConfigurationProperty("resolver-type")]
		public virtual string ResolverTypeName {
			get { return Convert.ToString(this["resolver-type"]); }
			set { this["resolver-type"] = value; }
		}

		[ConfigurationProperty("name")]
		public virtual string Name {
			get { return Convert.ToString(this["name"]); }
			set { this["name"] = value; }
		}

	}

}
