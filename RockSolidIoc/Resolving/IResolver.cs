using System;
using System.Reflection;

namespace RockSolidIoc
{

	public interface IResolver
	{

		object ResolveDependency(Type type, IIocContainer context);

	}

}
