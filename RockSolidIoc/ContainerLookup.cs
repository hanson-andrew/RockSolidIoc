using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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