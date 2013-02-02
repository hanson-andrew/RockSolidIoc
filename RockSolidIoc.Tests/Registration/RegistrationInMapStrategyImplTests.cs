using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class RegistrationInMapStrategyImplTests
  {
    [TestMethod]
    public void TestRegistrationInMap()
    {
      Type mappedType = typeof(object);
      string mappedIdentifier = "identifier";
      Type mappedToType = typeof(object);
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      mockedMap.Setup(map => map.IsInMap(mappedType, mappedIdentifier)).Returns(true);
      mockedMap.Setup(map => map.GetMappedObject(mappedType, mappedIdentifier)).Returns(mappedToType);

      RegistrationInMapStrategyImpl testStrategy = new RegistrationInMapStrategyImpl(() => mockedMap.Object);
      Assert.AreEqual(mappedToType, testStrategy.PickRegistration(mappedType, mappedIdentifier));
    }

    [TestMethod]
    public void TestNotInMapWithNextStep()
    {
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      Mock<PickRegistrationStrategy> mockedNextStep = new Mock<PickRegistrationStrategy>();

      RegistrationInMapStrategyImpl testStrategy = new RegistrationInMapStrategyImpl(() => mockedMap.Object);
      testStrategy.NextStep = mockedNextStep.Object;
      Type requestedType = typeof(object);
      string requestedIdentifer = "identifier";
      testStrategy.PickRegistration(typeof(object), requestedIdentifer);
      mockedNextStep.Verify(step => step.PickRegistration(requestedType, requestedIdentifer));
    }

    [TestMethod]
    public void TestNotInMapWithNoNextStep()
    {
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      RegistrationInMapStrategyImpl testStrategy = new RegistrationInMapStrategyImpl(() => mockedMap.Object);
      Assert.IsNull(testStrategy.PickRegistration(typeof(object), "identifier"));
    }
  }

}
