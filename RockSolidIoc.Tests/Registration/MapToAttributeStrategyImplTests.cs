using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class MapToAttributeStrategyImplTests
  {
    [TestMethod]
    public void TestWithAttributedObject()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      MapToAttributeStrategyImpl testStrategy = new MapToAttributeStrategyImpl();
      Type requestedType = typeof(ISimpleInterface);
      Assert.AreEqual(typeof(SimpleInterfaceImpl1), testStrategy.PickRegistration(requestedType, String.Empty));
      Assert.AreEqual(typeof(SimpleInterfaceImpl2), testStrategy.PickRegistration(requestedType, "2"));
    }

    [TestMethod]
    public void TestNoAttributesWithNextStep()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      MapToAttributeStrategyImpl testStrategy = new MapToAttributeStrategyImpl();
      Mock<PickRegistrationStrategy> mockNextStep = new Mock<PickRegistrationStrategy>();
      testStrategy.NextStep = mockNextStep.Object;
      Type requestedType = typeof(object);
      String requestedIdentifier = "identifier";
      testStrategy.PickRegistration(requestedType, requestedIdentifier);
      mockNextStep.Verify(step => step.PickRegistration(requestedType, requestedIdentifier));
    }

    [TestMethod]
    public void TestNoAttributesNoNextStep()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      MapToAttributeStrategyImpl testStrategy = new MapToAttributeStrategyImpl();
      Assert.IsNull(testStrategy.PickRegistration(typeof(object), "identifier"));
    }

  }

}