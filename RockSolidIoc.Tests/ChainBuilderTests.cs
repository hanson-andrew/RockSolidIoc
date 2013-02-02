using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ChainBuilderTests
  {
    [TestMethod]
    public void TestSingleLink()
    {
      ObjectChain initialStep = new ObjectChain();
      ChainBuilder<ObjectChain> testBuilder = ChainBuilder<ObjectChain>.Build(initialStep);
      ObjectChain resultingChain = testBuilder;
      Assert.AreEqual(initialStep, resultingChain);
    }

    [TestMethod]
    public void TestMultipleSteps()
    {
      ObjectChain initialStep = new ObjectChain();
      ObjectChain secondStep = new ObjectChain();
      ObjectChain thirdStep = new ObjectChain();
      ChainBuilder<ObjectChain> testBuilder = ChainBuilder<ObjectChain>.Build(initialStep).WithNextStep(secondStep).WithNextStep(thirdStep);
      ObjectChain resultingChain = testBuilder;
      Assert.AreEqual(initialStep, resultingChain);
      Assert.AreEqual(secondStep, initialStep.NextStep);
      Assert.AreEqual(thirdStep, secondStep.NextStep);
    }
  }

}
