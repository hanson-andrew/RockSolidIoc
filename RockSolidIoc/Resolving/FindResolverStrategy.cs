using System;

namespace RockSolidIoc
{

	public abstract class FindResolverStrategy : Strategy<FindResolverStrategy>
	{

		public abstract object FindResolver(Type type, string identifier);

	}

}
