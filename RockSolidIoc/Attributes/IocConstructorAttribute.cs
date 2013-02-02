using System;

namespace RockSolidIoc
{

	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	public sealed class IocConstructorAttribute : Attribute
	{

	}

}
