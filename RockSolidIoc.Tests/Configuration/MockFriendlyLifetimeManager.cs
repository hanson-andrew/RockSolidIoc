using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockSolidIoc.Tests
{

  class MockFriendlyLifetimeManager : MockContainer<ILifetimeManager>, ILifetimeManager
  {
    public void AddInstance(object value)
    {
      Mock.Object.AddInstance(value);
    }

    public object GetInstance()
    {
      return Mock.Object.GetInstance();
    }

    public void RemoveInstance()
    {
      Mock.Object.RemoveInstance();
    }

    public void Dispose()
    {
      Mock.Object.Dispose();
    }
  }

}
