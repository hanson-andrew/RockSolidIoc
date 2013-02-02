using System;
using System.Collections.Generic;

namespace RockSolidIoc
{

	internal class TypeResolvers
	{


		private IDictionary<Type, IDictionary<string, object>> _map = new Dictionary<Type, IDictionary<string, object>>();
		public void AddOrUpdate(Type type, string identifier, object resolver)
		{
			IDictionary<string, object> qualifiedMap = new Dictionary<string, object>();
			if (this._map.ContainsKey(type)) {
				qualifiedMap = this._map[type];
				if (qualifiedMap.ContainsKey(identifier)) {
					qualifiedMap[identifier] = resolver;
				} else {
					qualifiedMap.Add(identifier, resolver);
				}
			} else {
				qualifiedMap.Add(identifier, resolver);
				this._map.Add(type, qualifiedMap);
			}
		}

		public object GetResolver(Type type, string identifier)
		{
			if (this._map.ContainsKey(type)) {
				if (this._map[type].ContainsKey(identifier)) {
					return this._map[type][identifier];
				}
			}
			return null;
		}

	}

}
