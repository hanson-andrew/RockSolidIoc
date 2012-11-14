using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockSolidIoc
{
  public interface ILifetimeManager : IDisposable
  {
    object GetInstance();
    void RemoveInstance();
    void AddInstance(object value);
  }

}