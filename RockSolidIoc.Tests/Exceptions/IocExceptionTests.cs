using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Xunit;

namespace RockSolidIoc.Tests
{

  public class IocExceptionTests
  {

    [Fact()]
    public void TestStringConstructor()
    {
      string message = "message";
      IocException testException = new IocException(message);
      Assert.Equal(message, testException.Message);
    }

    [Fact()]
    public void TestStringExceptionConstructor()
    {
      string message = "message";
      Exception ex = new Exception();
      IocException testException = new IocException(message, ex);
      Assert.Equal(message, testException.Message);
      Assert.Equal(ex, testException.InnerException);
    }


  }

}