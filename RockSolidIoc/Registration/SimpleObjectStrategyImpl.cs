namespace RockSolidIoc
{

	public class SimpleObjectStrategyImpl : PickRegistrationStrategy
	{

		public override object PickRegistration(System.Type type, string identifier)
		{
			if (!type.IsAbstract && !type.IsInterface && !type.IsValueType) {
				return type;
			} else if ((this.NextStep != null)) {
				return this.NextStep.PickRegistration(type, identifier);
			}
			return null;
		}
	}

}
