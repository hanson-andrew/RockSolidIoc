using System;

namespace RockSolidIoc
{

	[AttributeUsage(AttributeTargets.Interface ^ AttributeTargets.Class, AllowMultiple = true)]
	public class MapToAttribute : Attribute
	{

		private Type _mappedType;

		private string _identifier;
		public MapToAttribute(Type mappedType)
		{
			this._mappedType = mappedType;
			this._identifier = string.Empty;
		}

		public MapToAttribute(Type mappedType, string identifier)
		{
			this._mappedType = mappedType;
			this._identifier = identifier;
		}

		public virtual Type MappedType {
			get { return this._mappedType; }
		}

		public virtual string Identifier {
			get { return this._identifier; }
		}

	}

}
