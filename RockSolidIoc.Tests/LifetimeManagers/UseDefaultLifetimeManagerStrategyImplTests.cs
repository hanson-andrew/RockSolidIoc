using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class UseDefaultLifetimeManagerStrategyImplTests
  {

    [TestMethod]
    public void TestFindLifetimeManager()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      UseDefaultLifetimeManagerStrategyImpl testStrategy = new UseDefaultLifetimeManagerStrategyImpl();
      Assert.IsInstanceOfType(testStrategy.FindLifetimeManager(typeof(object), "identifier"), typeof(TransientLifetimeManager));
    }

  }

}