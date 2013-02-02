using System;

namespace RockSolidIoc
{

	public class ResolverInMapStrategyImpl : FindResolverStrategy
	{


		private Func<IResolverMap> _getMap;
		public ResolverInMapStrategyImpl(Func<IResolverMap> getMap)
		{
			this._getMap = getMap;
		}

		public override object FindResolver(System.Type type, string identifier)
		{
			IResolverMap map = this._getMap.Invoke();
			if (map.IsInMap(type, identifier)) {
				return map.GetMappedObject(type, identifier);
			} else if ((this.NextStep != null)) {
				return this.NextStep.FindResolver(type, identifier);
			}
			return null;
		}
	}

}
