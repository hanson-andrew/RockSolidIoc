using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class TupleMap<T1, T2, TMappedTo> : ITupleMap<T1, T2, TMappedTo>
  {

    private bool _disposedValue = false;

    private IDictionary<T1, IDictionary<T2, TMappedTo>> _map = new Dictionary<T1, IDictionary<T2, TMappedTo>>();

    public void AddOrUpdate(T1 t1, T2 t2, TMappedTo tMappedTo)
    {
      IDictionary<T2, TMappedTo> qualifiedMap = new Dictionary<T2, TMappedTo>();
      if (this._map.ContainsKey(t1))
      {
        qualifiedMap = this._map[t1];
        if (qualifiedMap.ContainsKey(t2))
        {
          qualifiedMap[t2] = tMappedTo;
        }
        else
        {
          qualifiedMap.Add(t2, tMappedTo);
        }
      }
      else
      {
        qualifiedMap.Add(t2, tMappedTo);
        this._map.Add(t1, qualifiedMap);
      }
    }

    public bool IsInMap(T1 t1, T2 t2)
    {
      if (this._map.ContainsKey(t1))
      {
        return this._map[t1].ContainsKey(t2);
      }
      return false;
    }

    public TMappedTo GetMappedObject(T1 t1, T2 t2)
    {
      if (this._map.ContainsKey(t1))
      {
        if (this._map[t1].ContainsKey(t2))
        {
          return this._map[t1][t2];
        }
      }
      throw new ArgumentException(string.Format("Attempt to get mapped object for map keys {0} and {1} failed. No mapped object was found", t1, t2));
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposedValue)
      {
        if (disposing)
        {
          foreach (T1 k1 in this._map.Keys)
          {
            IDictionary<T2, TMappedTo> qualifiedMap = this._map[k1];
            foreach (T2 k2 in qualifiedMap.Keys)
            {
              object mappedTo = qualifiedMap[k2];
              if (mappedTo is IDisposable)
              {
                (mappedTo as IDisposable).Dispose();
              }
              if (k2 is IDisposable)
              {
                (k2 as IDisposable).Dispose();
              }
            }
            if (k1 is IDisposable)
            {
              (k1 as IDisposable).Dispose();
            }
          }
        }
      }
      this._disposedValue = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

  }
}