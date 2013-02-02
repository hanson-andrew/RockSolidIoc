using System;
using System.Configuration;

namespace RockSolidIoc
{

	public class TypeMappingConfigurationElement : ConfigurationElement
	{

		[ConfigurationProperty("type")]
		public virtual string TypeName {
			get { return Convert.ToString(this["type"]); }
			set { this["type"] = value; }
		}

		[ConfigurationProperty("mapTo")]
		public virtual string MapTo {
			get { return Convert.ToString(this["mapTo"]); }
			set { this["mapTo"] = value; }
		}

		[ConfigurationProperty("name")]
		public virtual string Name {
			get { return Convert.ToString(this["name"]); }
			set { this["name"] = value; }
		}

	}

}
