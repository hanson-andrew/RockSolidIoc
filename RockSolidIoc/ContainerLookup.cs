using System.Collections.Generic;

namespace RockSolidIoc
{

	public class ContainerLookup
	{


		private IDictionary<string, IIocContainer> _containers = new Dictionary<string, IIocContainer>();
		public IIocContainer GetContainer(string name)
		{
			return _containers[name];
		}

		public void AddContainer(string name, IIocContainer container)
		{
			this._containers.Add(name, container);
		}

	}

}
