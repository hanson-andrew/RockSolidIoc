using System;
using System.Collections.Generic;

namespace RockSolidIoc
{

	public class TypeMappingRegistration
	{

		private IDictionary<Type, IDictionary<string, Type>> _map = new Dictionary<Type, IDictionary<string, Type>>();
		public void AddOrUpdate(Type original, string identifier, Type implementation)
		{
            IDictionary<string, Type> qualifiedMap = new Dictionary<string, Type>();
			if (this._map.ContainsKey(original)) {
				qualifiedMap = this._map[original];
				if (qualifiedMap.ContainsKey(identifier)) {
					qualifiedMap[identifier]= implementation;
				} else {
					qualifiedMap.Add(identifier, implementation);
				}
			} else {
				qualifiedMap.Add(identifier, implementation);
				this._map.Add(original, qualifiedMap);
			}
		}

		public Type GetMappedType(Type original, string identifier)
		{
			if (this._map.ContainsKey(original)) {
				if (this._map[original].ContainsKey(identifier)) {
					return this._map[original][identifier];
				}
			}
			return null;
		}

	}

}
