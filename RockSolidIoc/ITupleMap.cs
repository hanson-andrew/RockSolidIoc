using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public interface ITupleMap<T1, T2, TMappedTo> : IDisposable
  {

    void AddOrUpdate(T1 t1, T2 t2, TMappedTo tMappedTo);
    bool IsInMap(T1 t1, T2 t2);
    TMappedTo GetMappedObject(T1 t1, T2 t2);

  }
}