using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class SimpleObjectStrategyImplTests
  {

    [TestMethod]
    public void TestIsSimple()
    {
      Type mappedType = typeof(object);
      string mappedIdentifier = "identifier";
      Type mappedToType = typeof(object);
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();

      SimpleObjectStrategyImpl testStrategy = new SimpleObjectStrategyImpl();
      Assert.AreEqual(mappedToType, testStrategy.PickRegistration(mappedType, mappedIdentifier));
    }

    [TestMethod]
    public void TestNotSimpleWithNextStep()
    {
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockedNextStep = new Mock<PickRegistrationStrategy>();

      SimpleObjectStrategyImpl testStrategy = new SimpleObjectStrategyImpl();
      testStrategy.NextStep = mockedNextStep.Object;
      Type requestedType = typeof(IDisposable);
      string requestedIdentifer = "identifier";
      testStrategy.PickRegistration(requestedType, requestedIdentifer);
      mockedNextStep.Verify(step => step.PickRegistration(requestedType, requestedIdentifer));
    }

    [TestMethod]
    public void TestNotSimpleWithNoNextStep()
    {
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      SimpleObjectStrategyImpl testStrategy = new SimpleObjectStrategyImpl();
      Assert.IsNull(testStrategy.PickRegistration(typeof(IDisposable), "identifier"));
    }

  }

}