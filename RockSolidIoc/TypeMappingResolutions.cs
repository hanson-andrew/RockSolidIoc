using System;
using System.Collections.Generic;

namespace RockSolidIoc
{

	public class TypeMappingResolutions
	{


		private IDictionary<Type, IDictionary<string, ILifetimeManager>> _map = new Dictionary<Type, IDictionary<string, ILifetimeManager>>();
		public void AddOrUpdate(Type type, string identifier, ILifetimeManager manager)
		{
			IDictionary<string, ILifetimeManager> qualifiedMap = new Dictionary<string, ILifetimeManager>();
			if (this._map.ContainsKey(type)) {
				qualifiedMap = this._map[type];
				if (qualifiedMap.ContainsKey(identifier)) {
					qualifiedMap[identifier] = manager;
				} else {
					qualifiedMap.Add(identifier, manager);
				}
			} else {
				qualifiedMap.Add(identifier, manager);
				this._map.Add(type, qualifiedMap);
			}
		}

		public object HasBeenResolved(Type type, string identifier)
		{
			if (this._map.ContainsKey(type)) {
				return this._map[type].ContainsKey(identifier);
			}
			return false;
		}

		public object GetLifetimeManager(Type type, string identifier)
		{
			if (this._map.ContainsKey(type)) {
				if (this._map[type].ContainsKey(identifier)) {
					return this._map[type][identifier];
				}
			}
			throw new IocException(string.Format("Attempt to get previous resolution for type {0} and identifier {1} failed. No previous resolution found", type.FullName, identifier));
		}

	}

}
