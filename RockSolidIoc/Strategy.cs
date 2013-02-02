namespace RockSolidIoc
{

	public abstract class Strategy<T> : IChain<T>
	{


		private T _nextStep;
		public virtual T NextStep {
			get { return this._nextStep; }
			set { this._nextStep = value; }
		}

	}

}
