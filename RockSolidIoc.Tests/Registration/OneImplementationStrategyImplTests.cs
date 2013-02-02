using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class OneImplementationStrategyImplTests
  {
    [TestMethod]
    public void TestWithAttributedObject()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      OneImplementationStrategyImpl testStrategy = new OneImplementationStrategyImpl();
      Type requestedType = typeof(ILoneInterface);
      Assert.AreEqual(typeof(ILoneInterfaceImpl), testStrategy.PickRegistration(requestedType, String.Empty));
    }

    [TestMethod]
    public void TestNoAttributesWithNextStep()
    {
      Mock<IRegistrationMap> mockMap = new Mock<IRegistrationMap>();
      OneImplementationStrategyImpl testStrategy = new OneImplementationStrategyImpl();
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
      OneImplementationStrategyImpl testStrategy = new OneImplementationStrategyImpl();
      Assert.IsNull(testStrategy.PickRegistration(typeof(object), "identifier"));
    }
  }

}