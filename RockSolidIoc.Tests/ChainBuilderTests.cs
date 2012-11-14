using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class ChainBuilderTests
  {
    [Fact()]
    public void TestSingleLink()
    {
      ObjectChain initialStep = new ObjectChain();
      ChainBuilder<ObjectChain> testBuilder = ChainBuilder<ObjectChain>.Build(initialStep);
      ObjectChain resultingChain = testBuilder;
      Assert.Equal(initialStep, resultingChain);
    }

    [Fact()]
    public void TestMultipleSteps()
    {
      ObjectChain initialStep = new ObjectChain();
      ObjectChain secondStep = new ObjectChain();
      ObjectChain thirdStep = new ObjectChain();
      ChainBuilder<ObjectChain> testBuilder = ChainBuilder<ObjectChain>.Build(initialStep).WithNextStep(secondStep).WithNextStep(thirdStep);
      ObjectChain resultingChain = testBuilder;
      Assert.Equal(initialStep, resultingChain);
      Assert.Equal(secondStep, initialStep.NextStep);
      Assert.Equal(thirdStep, secondStep.NextStep);
    }
  }

}
