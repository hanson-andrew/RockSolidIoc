using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class UseLifetimeManagerAttributeStrategyImplTests
  {

    [TestMethod]
    public void TestWithAttributedObject()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      UseLifetimeManagerAttributeStrategyImpl testStrategy = new UseLifetimeManagerAttributeStrategyImpl();
      Assert.AreEqual(typeof(ContainerManagedLifetimeManager), testStrategy.FindLifetimeManager(typeof(AttributedWithLifetimeManager), String.Empty));
      Assert.AreEqual(typeof(ExternallyControlledLifetimeManager), testStrategy.FindLifetimeManager(typeof(AttributedWithLifetimeManager), "weak"));
    }

    [TestMethod]
    public void TestNoAttributesWithNextStep()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      UseLifetimeManagerAttributeStrategyImpl testStrategy = new UseLifetimeManagerAttributeStrategyImpl();
      Mock<FindLifetimeManagerStrategy> mockedNextStep = new Mock<FindLifetimeManagerStrategy>();
      testStrategy.NextStep = mockedNextStep.Object;
      testStrategy.FindLifetimeManager(typeof(object), "identifier");
      mockedNextStep.Verify(step => step.FindLifetimeManager(It.IsAny<Type>(), It.IsAny<string>()));
    }

    [TestMethod]
    public void TestNoAttributesNoNextStep()
    {
      Mock<ILifetimeManagerMap> mockedMap = new Mock<ILifetimeManagerMap>();
      UseLifetimeManagerAttributeStrategyImpl testStrategy = new UseLifetimeManagerAttributeStrategyImpl();
      Assert.IsNull(testStrategy.FindLifetimeManager(typeof(object), "identifier"));
    }

  }

}