using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class RegistrationNotFoundStrategyImplTests
  {

    [Fact()]
    public void TestThrowsException()
    {
      RegistrationNotFoundStrategyImpl testStrategy = new RegistrationNotFoundStrategyImpl();
      Assert.Throws<IocException>(delegate { testStrategy.PickRegistration(new Mock<IRegistrationMap>().Object, typeof(object), "identifier"); });
    }
  }

}
