using System;
using System.Configuration;

namespace RockSolidIoc
{

	public class LifetimeManagerMappingConfigurationElement : ConfigurationElement
	{

		[ConfigurationProperty("type")]
		public virtual string TypeName {
			get { return Convert.ToString(this["type"]); }
			set { this["type"] = value; }
		}

		[ConfigurationProperty("lifetime-manager-type")]
		public virtual string LifetimeManagerTypeName {
			get { return Convert.ToString(this["lifetime-manager-type"]); }
			set { this["lifetime-manager-type"] = value; }
		}

		[ConfigurationProperty("name")]
		public virtual string Name {
			get { return Convert.ToString(this["name"]); }
			set { this["name"] = value; }
		}

	}

}
