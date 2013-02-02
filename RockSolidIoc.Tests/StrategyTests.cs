using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class StrategyTests
  {

    [TestMethod]
    public void TestNextStep()
    {
      ObjectStrategy nextStep = new ObjectStrategy();
      ObjectStrategy testStrategy = new ObjectStrategy();
      testStrategy.NextStep = nextStep;
      Assert.AreEqual(nextStep, testStrategy.NextStep);
    }

  }
}