using System;

namespace RockSolidIoc
{

	public class RegistrationInMapStrategyImpl : PickRegistrationStrategy
	{


		private Func<IRegistrationMap> _getRegistrationMap;
		public RegistrationInMapStrategyImpl(Func<IRegistrationMap> getRegistrationMap)
		{
			this._getRegistrationMap = getRegistrationMap;
		}

		public override object PickRegistration(System.Type type, string identifier)
		{
			IRegistrationMap registrationMap = this._getRegistrationMap.Invoke();
			if (registrationMap.IsInMap(type, identifier)) {
				return registrationMap.GetMappedObject(type, identifier);
			} else if ((base.NextStep != null)) {
				return this.NextStep.PickRegistration(type, identifier);
			}
			return null;
		}
	}

}
