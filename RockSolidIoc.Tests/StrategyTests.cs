using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class StrategyTests
  {

    [Fact()]
    public void TestNextStep()
    {
      ObjectStrategy nextStep = new ObjectStrategy();
      ObjectStrategy testStrategy = new ObjectStrategy();
      testStrategy.NextStep = nextStep;
      Assert.Equal(nextStep, testStrategy.NextStep);
    }

  }
}