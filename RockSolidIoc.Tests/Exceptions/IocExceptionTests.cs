using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class IocExceptionTests
  {

    [TestMethod]
    public void TestStringConstructor()
    {
      string message = "message";
      IocException testException = new IocException(message);
      Assert.AreEqual(message, testException.Message);
    }

    [TestMethod]
    public void TestStringExceptionConstructor()
    {
      string message = "message";
      Exception ex = new Exception();
      IocException testException = new IocException(message, ex);
      Assert.AreEqual(message, testException.Message);
      Assert.AreEqual(ex, testException.InnerException);
    }


  }

}