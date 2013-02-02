using System;

namespace RockSolidIoc
{

	public interface ILifetimeManager : IDisposable
	{

		object GetInstance();
		void RemoveInstance();

		void AddInstance(object value);
	}

}
