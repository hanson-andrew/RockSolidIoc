using System;

namespace RockSolidIoc
{

	public abstract class PickRegistrationStrategy : Strategy<PickRegistrationStrategy>
	{

		public abstract object PickRegistration(Type type, string identifier);

	}

}
