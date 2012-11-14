using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class SimpleObjectStrategyImplTests
  {

    [Fact()]
    public void TestIsSimple()
    {
      Type mappedType = typeof(object);
      string mappedIdentifier = "identifier";
      Type mappedToType = typeof(object);
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();

      SimpleObjectStrategyImpl testStrategy = new SimpleObjectStrategyImpl();
      Assert.Equal(mappedToType, testStrategy.PickRegistration(mockedMap.Object, mappedType, mappedIdentifier));
    }

    [Fact()]
    public void TestNotSimpleWithNextStep()
    {
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockedNextStep = new Mock<PickRegistrationStrategy>();

      SimpleObjectStrategyImpl testStrategy = new SimpleObjectStrategyImpl();
      testStrategy.NextStep = mockedNextStep.Object;
      Type requestedType = typeof(IDisposable);
      string requestedIdentifer = "identifier";
      testStrategy.PickRegistration(mockedMap.Object, requestedType, requestedIdentifer);
      mockedNextStep.Verify(step => step.PickRegistration(mockedMap.Object, requestedType, requestedIdentifer));
    }

    [Fact()]
    public void TestNotSimpleWithNoNextStep()
    {
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      SimpleObjectStrategyImpl testStrategy = new SimpleObjectStrategyImpl();
      Assert.Null(testStrategy.PickRegistration(mockedMap.Object, typeof(IDisposable), "identifier"));
    }

  }

}