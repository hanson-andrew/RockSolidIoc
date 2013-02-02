namespace RockSolidIoc
{

	public class UseDefaultLifetimeManagerStrategyImpl : FindLifetimeManagerStrategy
	{

		public override object FindLifetimeManager(System.Type type, string identifier)
		{
			return new TransientLifetimeManager();
		}

	}

}
