using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class UseDefaultResolverStrategyImplTests
  {

    [TestMethod]
    public void TestFindResolver()
    {
      Mock<IResolverMap> mockedMap = new Mock<IResolverMap>();
      UseDefaultResolverStrategyImpl testStrategy = new UseDefaultResolverStrategyImpl();
      Assert.IsInstanceOfType(testStrategy.FindResolver(typeof(object), "identifier"), typeof(Resolver));
    }

  }

}