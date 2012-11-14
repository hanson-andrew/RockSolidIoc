using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;

namespace RockSolidIoc.Tests
{

  internal class MockContainer<T> where T : class
  {
    private static Mock<T> _mock = new Mock<T>();

    static internal Mock<T> Mock
    {
      get
      {
        return _mock;
      }
    }

    static internal void ResetMock()
    {
      _mock = new Mock<T>();
    }
  }

}