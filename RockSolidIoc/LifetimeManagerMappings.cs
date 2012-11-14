using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc
{

  internal class LifetimeManagerMappings : IDisposable
  {
    private bool _disposedValue = false;

    private IDictionary<Type, object> _map = new Dictionary<Type, object>();

    public void AddOrUpdate(Type type, object manager)
    {
      if(this._map.ContainsKey(type))
      {
        this._map[type] = manager;
      }
      else
      {
        this._map.Add(type, manager);
      } 
    }

    public object GetLifetimeManager(Type type)
    {
      return this._map;
    }

    protected virtual void Dispose(bool disposing)
    {
      if(!this._disposedValue)
      {
        if(disposing)
        {
          foreach(IDictionary<string, RegistrationEntry> identifierRegistration in this._map.Values)
          {
            foreach(ILifetimeManager entry in identifierRegistration.Values)
            {
              if(!this.Equals(entry.GetInstance)) //Each IocContainer registers itself within itself, so prevent recursing and an eventual stack overflow here
              {
                entry.Dispose();
              }
            }
          }
        }
      }
      this._disposedValue = true;
    }

    public virtual void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    }

}