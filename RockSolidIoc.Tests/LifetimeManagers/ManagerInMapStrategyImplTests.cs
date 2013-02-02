using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ManagerInMapStrategyImplTests
  {

    [TestMethod]
    public void TestManagerInMap()
    {
      Type mappedType = typeof(object);
      string mappedIdentifier = "identifier";
      object mappedObject = new object();
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      mockedMap.Setup(map => map.IsInMap(mappedType, mappedIdentifier)).Returns(true);
      mockedMap.Setup(map => map.GetMappedObject(mappedType, mappedIdentifier)).Returns(mappedObject);

      ManagerInMapStrategyImpl testStrategy = new ManagerInMapStrategyImpl(() => mockedMap.Object);
      Assert.AreEqual(mappedObject, testStrategy.FindLifetimeManager(mappedType, mappedIdentifier));
    }

    [TestMethod]
    public void TestNotInMapWithNextStep()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      Mock<FindLifetimeManagerStrategy> mockedNextStep = new Mock<FindLifetimeManagerStrategy>();

      ManagerInMapStrategyImpl testStrategy = new ManagerInMapStrategyImpl(() => mockedMap.Object);
      testStrategy.NextStep = mockedNextStep.Object;
      testStrategy.FindLifetimeManager(typeof(object), "identifier");
      mockedNextStep.Verify(step => step.FindLifetimeManager(It.IsAny<Type>(), It.IsAny<string>()));
    }

    [TestMethod]
    public void TestNotInMapWithNoNextStep()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      ManagerInMapStrategyImpl testStrategy = new ManagerInMapStrategyImpl(() => mockedMap.Object);
      Assert.IsNull(testStrategy.FindLifetimeManager(typeof(object), "identifier"));
    }
  }

}