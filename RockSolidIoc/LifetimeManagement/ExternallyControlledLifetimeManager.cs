﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class ExternallyControlledLifetimeManager : ILifetimeManager
  {

    private WeakReference _reference = new WeakReference(null);

    public virtual void AddInstance(object value)
    {
      _reference = new WeakReference(value);
    }

    protected virtual void Dispose(bool disposing)
    {
      //We don't control the reference so leave it be
    }

    public virtual object GetInstance()
    {
      return _reference.Target;
    }

    public virtual void RemoveInstance()
    {
      //We don't control the reference so leave it be
    }

    public virtual void Dispose()
    {
      this.Dispose(true);
    }

  }
}