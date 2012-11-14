using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class MapToAttributeStrategyImplTests
  {
    [Fact()]
    public void TestWithAttributedObject()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      MapToAttributeStrategyImpl testStrategy = new MapToAttributeStrategyImpl();
      Type requestedType = typeof(ISimpleInterface);
      Assert.Equal(typeof(SimpleInterfaceImpl1), testStrategy.PickRegistration(mockMap.Object, requestedType, String.Empty));
      Assert.Equal(typeof(SimpleInterfaceImpl2), testStrategy.PickRegistration(mockMap.Object, requestedType, "2"));
    }

    [Fact()]
    public void TestNoAttributesWithNextStep()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      MapToAttributeStrategyImpl testStrategy = new MapToAttributeStrategyImpl();
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
      MapToAttributeStrategyImpl testStrategy = new MapToAttributeStrategyImpl();
      Assert.Null(testStrategy.PickRegistration(mockMap.Object, typeof(object), "identifier"));
    }

  }

}