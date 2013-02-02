using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ResolverInMapStrategyImplTests
  {
    [TestMethod]
    public void TestResolverInMap()
    {
      Type mappedType = typeof(object);
      string mappedIdentifier = "identifier";
      object mappedObject = new object();
      Mock<IResolverMap> mockedMap = new Mock<IResolverMap>();
      mockedMap.Setup(map => map.IsInMap(mappedType, mappedIdentifier)).Returns(true);
      mockedMap.Setup(map => map.GetMappedObject(mappedType, mappedIdentifier)).Returns(mappedObject);

      ResolverInMapStrategyImpl testStrategy = new ResolverInMapStrategyImpl(() => mockedMap.Object);
      Assert.AreEqual(mappedObject, testStrategy.FindResolver(mappedType, mappedIdentifier));
    }

    [TestMethod]
    public void TestNotInMapWithNextStep()
    {
      Mock<IResolverMap> mockedMap = new Mock<IResolverMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      Mock<FindResolverStrategy> mockedNextStep = new Mock<FindResolverStrategy>();

      ResolverInMapStrategyImpl testStrategy = new ResolverInMapStrategyImpl(() => mockedMap.Object);
      testStrategy.NextStep = mockedNextStep.Object;
      Type requestedType = typeof(object);
      string requestedIdentifer = "identifier";
      testStrategy.FindResolver(requestedType, requestedIdentifer);
      mockedNextStep.Verify(step => step.FindResolver(requestedType, requestedIdentifer));
    }

    [TestMethod]
    public void TestNotInMapWithNoNextStep()
    {
      Mock<IResolverMap> mockedMap = new Mock<IResolverMap>();
      mockedMap.Setup(map => map.IsInMap(It.IsAny<Type>(), It.IsAny<string>())).Returns(false);
      ResolverInMapStrategyImpl testStrategy = new ResolverInMapStrategyImpl(() => mockedMap.Object);
      Assert.IsNull(testStrategy.FindResolver(typeof(object), "identifier"));
    }
  }

}