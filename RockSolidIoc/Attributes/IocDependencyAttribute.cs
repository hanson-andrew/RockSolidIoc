using System;

namespace RockSolidIoc
{

	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Method)]
	public sealed class IocDependencyAttribute : Attribute
	{


		private string _identifier;
		public IocDependencyAttribute() : this(string.Empty)
		{
		}

		public IocDependencyAttribute(string identifier)
		{
			this._identifier = identifier;
		}

		public string Identifier {
			get { return this._identifier; }
			set { this._identifier = value; }
		}

	}

}
