namespace RockSolidIoc
{

	public class ChainBuilder<T> where T : IChain<T>
	{

		private IChain<T> _chainHead;

		private IChain<T> _currentLink;
		private ChainBuilder(T chainHead)
		{
			this._chainHead = chainHead;
			this._currentLink = chainHead;
		}

		public static ChainBuilder<T> Build(T chainHead)
		{
			return new ChainBuilder<T>(chainHead);
		}

		public ChainBuilder<T> WithNextStep(T nextStep)
		{
			this._currentLink.NextStep = nextStep;
			this._currentLink = nextStep;
			return this;
		}

		public static implicit operator T(ChainBuilder<T> p1)
		{
			return (T)p1._chainHead;
		}

	}

}
