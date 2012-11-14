using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class OneImplementationStrategyImplTests
  {
    [Fact()]
    public void TestWithAttributedObject()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      OneImplementationStrategyImpl testStrategy = new OneImplementationStrategyImpl();
      Type requestedType = typeof(ILoneInterface);
      Assert.Equal(typeof(ILoneInterfaceImpl), testStrategy.PickRegistration(mockMap.Object, requestedType, String.Empty));
    }

    [Fact()]
    public void TestNoAttributesWithNextStep()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      OneImplementationStrategyImpl testStrategy = new OneImplementationStrategyImpl();
      Mock<PickRegistrationStrategy> mockNextStep = new Mock<PickRegistrationStrategy>();
      testStrategy.NextStep = mockNextStep.Object;
      Type requestedType = typeof(object);
      String requestedIdentifier = "identifier";
      testStrategy.PickRegistration(mockMap.Object, requestedType, requestedIdentifier);
      mockNextStep.Verify(step => step.PickRegistration(mockMap.Object, requestedType, requestedIdentifier));
    }

    [Fact()]
    public void TestNoAttributesNoNextStep()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      OneImplementationStrategyImpl testStrategy = new OneImplementationStrategyImpl();
      Assert.Null(testStrategy.PickRegistration(mockMap.Object, typeof(object), "identifier"));
    }
  }

}