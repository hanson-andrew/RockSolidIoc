using System;

namespace RockSolidIoc
{

	public abstract class FindLifetimeManagerStrategy : Strategy<FindLifetimeManagerStrategy>
	{

		public abstract object FindLifetimeManager(Type type, string identifier);

	}

}
