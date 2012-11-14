using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  public class ContainerManagedLifetimeManager : ILifetimeManager
  {

    private bool isDisposed;

    private object _instance;

    public virtual void AddInstance(object value)
    {
      if (isDisposed)
      {
        throw new ObjectDisposedException("ContainerManagedLifetimeManager");
      }
      this._instance = value;
    }

    public virtual object GetInstance()
    {
      if (isDisposed)
      {
        throw new ObjectDisposedException("ContainerManagedLifetimeManager");
      }
      return this._instance;
    }

    public virtual void RemoveInstance()
    {
      if (isDisposed)
      {
        throw new ObjectDisposedException("ContainerManagedLifetimeManager");
      }
      //I use the ClearInstance here instead of embedding the clear logic here because
      //the same logic is used on Dispose
      this.ClearInstance();
    }

    public virtual void Dispose()
    {
      if (isDisposed)
      {
        throw new ObjectDisposedException("ContainerManagedLifetimeManager");
      }
      this.Dispose(true);
    }

    protected void Dispose(bool disposing)
    {
      if (!this.isDisposed)
      {
        if (disposing)
        {
          this.ClearInstance();
        }
      }
      this.isDisposed = true;
    }

    private void ClearInstance()
    {
      if (_instance is IDisposable)
      {
        (_instance as IDisposable).Dispose();
      }
      this._instance = null;
    }

  }

}