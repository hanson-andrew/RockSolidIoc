using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class ManagerInMapStrategyImplTests
  {

    [Fact()]
    public void TestManagerInMap()
    {
      Type mappedType = typeof(object);
      string mappedIdentifier = "identifier";
      object mappedObject = new object();
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      mockedMap.Setup(map => map.IsInMap(mappedType, mappedIdentifier)).Returns(true);
      mockedMap.Setup(map => map.GetMappedObject(mappedType, mappedIdentifier)).Returns(mappedObject);

      ManagerInMapStrategyImpl testStrategy = new ManagerInMapStrategyImpl();
      Assert.Equal(mappedObject, testStrategy.FindLifetimeManager(mockedMap.Object, mappedType, mappedIdentifier));
    }

    [Fact()]
    public void TestNotInMapWithNextStep()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      Mock<FindLifetimeManagerStrategy> mockedNextStep = new Mock<FindLifetimeManagerStrategy>();

      ManagerInMapStrategyImpl testStrategy = new ManagerInMapStrategyImpl();
      testStrategy.NextStep = mockedNextStep.Object;
      testStrategy.FindLifetimeManager(mockedMap.Object, typeof(object), "identifier");
      mockedNextStep.Verify(step => step.FindLifetimeManager(It.IsAny<ILifetimeManagerMap>(), It.IsAny<Type>(), It.IsAny<string>()));
    }

    [Fact()]
    public void TestNotInMapWithNoNextStep()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      ManagerInMapStrategyImpl testStrategy = new ManagerInMapStrategyImpl();
      Assert.Null(testStrategy.FindLifetimeManager(mockedMap.Object, typeof(object), "identifier"));
    }
  }

}