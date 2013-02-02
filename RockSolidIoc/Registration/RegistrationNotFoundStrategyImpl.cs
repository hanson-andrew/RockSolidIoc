using System;

namespace RockSolidIoc
{

	public class RegistrationNotFoundStrategyImpl : PickRegistrationStrategy
	{

		public override object PickRegistration(Type type, string identifier)
		{
			throw new IocException(string.Format("Failed to find a registration for type {0} with identifier {1}", type.FullName, identifier));
		}
	}

}
