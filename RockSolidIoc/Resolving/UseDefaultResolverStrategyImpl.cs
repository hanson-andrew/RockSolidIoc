namespace RockSolidIoc
{

	public class UseDefaultResolverStrategyImpl : FindResolverStrategy
	{

		public override object FindResolver(System.Type type, string identifier)
		{
			return new Resolver();
		}

	}

}
