using System;

namespace RockSolidIoc
{

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class UseIResolverAttribute : Attribute
	{

		private Type _type;

		private string _identifier;
		public UseIResolverAttribute(Type type)
		{
			this._type = type;
			this._identifier = string.Empty;
		}

		public UseIResolverAttribute(Type type, string identifier)
		{
			this._type = type;
			this._identifier = identifier;
		}

		public virtual Type Type {
			get { return this._type; }
		}

		public virtual string Identifier {
			get { return this._identifier; }
		}

	}

}
