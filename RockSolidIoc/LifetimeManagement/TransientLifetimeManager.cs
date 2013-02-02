namespace RockSolidIoc
{

	public class TransientLifetimeManager : ILifetimeManager
	{

		public virtual void AddInstance(object value)
		{
			//This is an empty stub on purpose. This lifetime manager is made to force a new instance everytime one is needed
		}

		public virtual object GetInstance()
		{
			//This is an empty stub on purpose. This lifetime manager is made to force a new instance everytime one is needed
			return null;
		}

		public virtual void RemoveInstance()
		{
			//This is an empty stub on purpose. This lifetime manager is made to force a new instance everytime one is needed
		}

		public virtual void Dispose()
		{
			this.Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			//This is an empty stub on purpose. This lifetime manager is made to force a new instance everytime one is needed
		}

	}

}
