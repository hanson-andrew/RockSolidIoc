namespace RockSolidIoc
{

	public class UseLifetimeManagerAttributeStrategyImpl : FindLifetimeManagerStrategy
	{

		public override object FindLifetimeManager(System.Type type, string identifier)
		{
			object[] attributes = type.GetCustomAttributes(typeof(UseLifetimeManagerAttribute), false);
			foreach (object a in attributes) {
				UseLifetimeManagerAttribute useAttribute = (UseLifetimeManagerAttribute)a;
				if (string.Equals(identifier, useAttribute.Identifier)) {
					return useAttribute.Type;
				}
			}
			if ((this.NextStep != null)) {
				return this.NextStep.FindLifetimeManager(type, identifier);
			}
			return null;
		}

	}

}
