using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class UseDefaultLifetimeManagerStrategyImplTests
  {

    [Fact()]
    public void TestFindLifetimeManager()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      UseDefaultLifetimeManagerStrategyImpl testStrategy = new UseDefaultLifetimeManagerStrategyImpl();
      Assert.IsType<TransientLifetimeManager>(testStrategy.FindLifetimeManager(mockedMap.Object, typeof(object), "identifier"));
    }

  }

}