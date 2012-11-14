using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class UseDefaultResolverStrategyImplTests
  {

    [Fact()]
    public void TestFindResolver()
    {
      Mock<IInstantiatorMap> mockedMap = new Mock<IInstantiatorMap>();
      UseDefaultInstantiatorStrategyImpl testStrategy = new UseDefaultInstantiatorStrategyImpl();
      Assert.IsType<DefaultInstantiator>(testStrategy.FindInstantiator(mockedMap.Object, typeof(object), "identifier"));
    }

  }

}