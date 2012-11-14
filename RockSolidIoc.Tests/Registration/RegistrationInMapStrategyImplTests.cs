using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class RegistrationInMapStrategyImplTests
  {
    [Fact()]
    public void TestRegistrationInMap()
    {
      Type mappedType = typeof(object);
      string mappedIdentifier = "identifier";
      Type mappedToType = typeof(object);
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      mockedMap.Setup(map => map.IsInMap(mappedType, mappedIdentifier)).Returns(true);
      mockedMap.Setup(map => map.GetMappedObject(mappedType, mappedIdentifier)).Returns(mappedToType);

      RegistrationInMapStrategyImpl testStrategy = new RegistrationInMapStrategyImpl();
      Assert.Equal(mappedToType, testStrategy.PickRegistration(mockedMap.Object, mappedType, mappedIdentifier));
    }

    [Fact()]
    public void TestNotInMapWithNextStep()
    {
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      Mock<PickRegistrationStrategy> mockedNextStep = new Mock<PickRegistrationStrategy>();

      RegistrationInMapStrategyImpl testStrategy = new RegistrationInMapStrategyImpl();
      testStrategy.NextStep = mockedNextStep.Object;
      Type requestedType = typeof(object);
      string requestedIdentifer = "identifier";
      testStrategy.PickRegistration(mockedMap.Object, typeof(object), requestedIdentifer);
      mockedNextStep.Verify(step => step.PickRegistration(mockedMap.Object, requestedType, requestedIdentifer));
    }

    [Fact()]
    public void TestNotInMapWithNoNextStep()
    {
      Mock<IRegistrationMap> mockedMap = new Mock<IRegistrationMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      RegistrationInMapStrategyImpl testStrategy = new RegistrationInMapStrategyImpl();
      Assert.Null(testStrategy.PickRegistration(mockedMap.Object, typeof(object), "identifier"));
    }
  }

}
