namespace RockSolidIoc
{

	public class UseResolverAttributeStrategyImpl : FindResolverStrategy
	{

		public override object FindResolver(System.Type type, string identifier)
		{
			object[] attributes = type.GetCustomAttributes(typeof(UseIResolverAttribute), false);
			foreach (object a in attributes) {
				UseIResolverAttribute useIResolver = (UseIResolverAttribute)a;
				if (string.Equals(identifier, useIResolver.Identifier)) {
					return useIResolver.Type;
				}
			}
			if ((this.NextStep != null)) {
				return this.NextStep.FindResolver(type, identifier);
			}
			return null;
		}

	}

}
