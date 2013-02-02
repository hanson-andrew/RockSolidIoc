using System;

namespace RockSolidIoc
{

	public class ManagerInMapStrategyImpl : FindLifetimeManagerStrategy
	{


		private Func<ILifetimeManagerMap> _getMap;
		public ManagerInMapStrategyImpl(Func<ILifetimeManagerMap> getMap)
		{
			this._getMap = getMap;
		}

		public override object FindLifetimeManager(System.Type type, string identifier)
		{
			ILifetimeManagerMap map = this._getMap.Invoke();
			if (map.IsInMap(type, identifier)) {
				return map.GetMappedObject(type, identifier);
			} else if ((this.NextStep != null)) {
				return this.NextStep.FindLifetimeManager(type, identifier);
			}
			return null;
		}

	}

}
