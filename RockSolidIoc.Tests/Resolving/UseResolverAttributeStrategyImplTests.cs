using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class UseResolverAttributeStrategyImplTests
  {

    [Fact()]
    public void TestWithAttributedObject()
    {
      Mock<IInstantiatorMap> mockMap = new Mock<IInstantiatorMap>();
      UseInstantiatorAttributeStrategyImpl testStrategy = new UseInstantiatorAttributeStrategyImpl();
      Type requestedType = typeof(AttributedWithResolver);
      Assert.Equal(typeof(ResolverImpl1), testStrategy.FindInstantiator(mockMap.Object, requestedType, String.Empty));
      Assert.Equal(typeof(ResolverImpl2), testStrategy.FindInstantiator(mockMap.Object, requestedType, "2"));
    }

    [Fact()]
    public void TestNoAttributesWithNextStep()
    {
      Mock<IInstantiatorMap> mockMap = new Mock<IInstantiatorMap>();
      UseInstantiatorAttributeStrategyImpl testStrategy = new UseInstantiatorAttributeStrategyImpl();
      Mock<FindInstantiatorStrategy> mockNextStep = new Mock<FindInstantiatorStrategy>();
      testStrategy.NextStep = mockNextStep.Object;
      Type requestedType = typeof(object);
      String requestedIdentifier = "identifier";
      testStrategy.FindInstantiator(mockMap.Object, requestedType, requestedIdentifier);
      mockNextStep.Verify(step => step.FindInstantiator(mockMap.Object, requestedType, requestedIdentifier));
    }

    [Fact()]
    public void TestNoAttributesNoNextStep()
    {
      Mock<IInstantiatorMap> mockMap = new Mock<IInstantiatorMap>();
      UseInstantiatorAttributeStrategyImpl testStrategy = new UseInstantiatorAttributeStrategyImpl();
      Assert.Null(testStrategy.FindInstantiator(mockMap.Object, typeof(object), "identifier"));
    }

  }

}