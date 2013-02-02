using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{

  [TestClass]
  public class RegistrationNotFoundStrategyImplTests
  {

    [TestMethod]
    public void TestThrowsException()
    {
      RegistrationNotFoundStrategyImpl testStrategy = new RegistrationNotFoundStrategyImpl();
      try
      {
        testStrategy.PickRegistration(typeof(object), "identified");
        Assert.Fail();
      }
      catch (IocException) { }
    }
  }

}
