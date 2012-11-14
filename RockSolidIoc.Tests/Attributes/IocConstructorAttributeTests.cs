using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JordansLibrary.Ioc;

using Xunit;

namespace JordansLibrary.Tests.Ioc
{
  public class IocConstructorAttributeTests
  {
    [Fact()]
    public void TestConstructor()
    {
      try
      {
        IocConstructorAttribute testAttribute = new IocConstructorAttribute();
      }
      catch
      {
        Assert.Fail("Exception was thrown when instantiating the object");
      }
    }
  }
}
