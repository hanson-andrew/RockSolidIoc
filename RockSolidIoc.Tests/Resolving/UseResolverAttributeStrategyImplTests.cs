using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class UseResolverAttributeStrategyImplTests
  {

    [TestMethod]
    public void TestWithAttributedObject()
    {
      Mock<IResolverMap> mockMap = new Mock<IResolverMap>();
      UseResolverAttributeStrategyImpl testStrategy = new UseResolverAttributeStrategyImpl();
      Type requestedType = typeof(AttributedWithResolver);
      Assert.AreEqual(typeof(ResolverImpl1), testStrategy.FindResolver(requestedType, String.Empty));
      Assert.AreEqual(typeof(ResolverImpl2), testStrategy.FindResolver(requestedType, "2"));
    }

    [TestMethod]
    public void TestNoAttributesWithNextStep()
    {
      Mock<IResolverMap> mockMap = new Mock<IResolverMap>();
      UseResolverAttributeStrategyImpl testStrategy = new UseResolverAttributeStrategyImpl();
      Mock<FindResolverStrategy> mockNextStep = new Mock<FindResolverStrategy>();
      testStrategy.NextStep = mockNextStep.Object;
      Type requestedType = typeof(object);
      String requestedIdentifier = "identifier";
      testStrategy.FindResolver(requestedType, requestedIdentifier);
      mockNextStep.Verify(step => step.FindResolver(requestedType, requestedIdentifier));
    }

    [TestMethod]
    public void TestNoAttributesNoNextStep()
    {
      Mock<IResolverMap> mockMap = new Mock<IResolverMap>();
      UseResolverAttributeStrategyImpl testStrategy = new UseResolverAttributeStrategyImpl();
      Assert.IsNull(testStrategy.FindResolver(typeof(object), "identifier"));
    }

  }

}