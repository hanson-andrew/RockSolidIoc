using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class UseLifetimeManagerAttributeStrategyImplTests
  {

    [Fact()]
    public void TestWithAttributedObject()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      UseLifetimeManagerAttributeStrategyImpl testStrategy = new UseLifetimeManagerAttributeStrategyImpl();
      Assert.Equal(typeof(ContainerManagedLifetimeManager), testStrategy.FindLifetimeManager(mockedMap.Object, typeof(AttributedWithLifetimeManager), String.Empty));
      Assert.Equal(typeof(ExternallyControlledLifetimeManager), testStrategy.FindLifetimeManager(mockedMap.Object, typeof(AttributedWithLifetimeManager), "weak"));
    }

    [Fact()]
    public void TestNoAttributesWithNextStep()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      UseLifetimeManagerAttributeStrategyImpl testStrategy = new UseLifetimeManagerAttributeStrategyImpl();
      Mock<FindLifetimeManagerStrategy> mockedNextStep = new Mock<FindLifetimeManagerStrategy>();
      testStrategy.NextStep = mockedNextStep.Object;
      testStrategy.FindLifetimeManager(mockedMap.Object, typeof(object), "identifier");
      mockedNextStep.Verify(step => step.FindLifetimeManager(It.IsAny<ILifetimeManagerMap>(), It.IsAny<Type>(), It.IsAny<string>()));
    }

    [Fact()]
    public void TestNoAttributesNoNextStep()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      UseLifetimeManagerAttributeStrategyImpl testStrategy = new UseLifetimeManagerAttributeStrategyImpl();
      Assert.Null(testStrategy.FindLifetimeManager(mockedMap.Object, typeof(object), "identifier"));
    }

  }

}