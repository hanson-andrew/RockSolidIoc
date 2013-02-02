namespace RockSolidIoc
{

	public class MapToAttributeStrategyImpl : PickRegistrationStrategy
	{

		public override object PickRegistration(System.Type type, string identifier)
		{
			object[] mappingAttributes = type.GetCustomAttributes(typeof(MapToAttribute), false);
			foreach (object a in mappingAttributes) {
				MapToAttribute mapTo = (MapToAttribute)a;
				if (string.Equals(mapTo.Identifier, identifier)) {
					return mapTo.MappedType;
				}
			}
			if ((this.NextStep != null)) {
				return this.NextStep.PickRegistration(type, identifier);
			}
			return null;
		}

	}

}
