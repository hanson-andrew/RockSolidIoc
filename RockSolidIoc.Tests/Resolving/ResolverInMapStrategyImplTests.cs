using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class ResolverInMapStrategyImplTests
  {
    [Fact()]
    public void TestResolverInMap()
    {
      Type mappedType = typeof(object);
      string mappedIdentifier = "identifier";
      object mappedObject = new object();
      Mock<IInstantiatorMap> mockedMap = new Mock<IInstantiatorMap>();
      mockedMap.Setup(map => map.IsInMap(mappedType, mappedIdentifier)).Returns(true);
      mockedMap.Setup(map => map.GetMappedObject(mappedType, mappedIdentifier)).Returns(mappedObject);

      InstantiatorInMapStrategyImpl testStrategy = new InstantiatorInMapStrategyImpl();
      Assert.Equal(mappedObject, testStrategy.FindInstantiator(mockedMap.Object, mappedType, mappedIdentifier));
    }

    [Fact()]
    public void TestNotInMapWithNextStep()
    {
      Mock<IInstantiatorMap> mockedMap = new Mock<IInstantiatorMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      Mock<FindInstantiatorStrategy> mockedNextStep = new Mock<FindInstantiatorStrategy>();

      InstantiatorInMapStrategyImpl testStrategy = new InstantiatorInMapStrategyImpl();
      testStrategy.NextStep = mockedNextStep.Object;
      Type requestedType = typeof(object);
      string requestedIdentifer = "identifier";
      testStrategy.FindInstantiator(mockedMap.Object, requestedType, requestedIdentifer);
      mockedNextStep.Verify(step => step.FindInstantiator(mockedMap.Object, requestedType, requestedIdentifer));
    }

    [Fact()]
    public void TestNotInMapWithNoNextStep()
    {
      Mock<IInstantiatorMap> mockedMap = new Mock<IInstantiatorMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      InstantiatorInMapStrategyImpl testStrategy = new InstantiatorInMapStrategyImpl();
      Assert.Null(testStrategy.FindInstantiator(mockedMap.Object, typeof(object), "identifier"));
    }
  }

}