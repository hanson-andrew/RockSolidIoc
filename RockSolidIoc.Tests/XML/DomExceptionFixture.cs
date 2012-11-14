using System.Runtime.Serialization;
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JordansLibrary.Xml;

namespace JordansLibrary.Tests.Xml
{
  [TestClass()]
  public class DomExceptionFixture
  {

    [TestMethod()]
    public void TestDefaultConstructor()
    {
      try
      {
        DomException domException = new DomException();
      }
      catch (Exception ex)
      {
        Assert.Fail(String.Format("Expected no exception but got {0}", ex.ToString()));
      }
    }

    [TestMethod()]
    public void TestStringConstructor()
    {
      DomException domException = new DomException("test_message");
      Assert.AreEqual(domException.Message, "test_message");
    }

    [TestMethod()]
    public void TestStringExceptionConstructor()
    {
      Exception innerException = new Exception();
      DomException domException = new DomException("test_message", innerException);
      Assert.AreEqual(domException.Message, "test_message");
      Assert.AreEqual(domException.InnerException, innerException);
    }

    [TestMethod()]
    public void TestSerialization()
    {
      //Opted not to stub the serialization because it was just easier to actually serialize and deserialize completely
      Exception innerException = new Exception();
      DomException domException = new DomException("test_message", innerException);
      System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
      System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
      formatter.Serialize(memoryStream, domException);
      memoryStream.Position = 0;
      //We use a custom serialization binder because for some reason, when run in visual studio (using Visual NUnit)
      //the test can't find the assembly appropriately.
      //This isn't needed to run the test in the NUnit runner (or perhaps other runners), but doesn't break them either.
      SerializationBinder customBinder = new CustomSerializationBinder();
      formatter.Binder = customBinder;
      Object obj = formatter.Deserialize(memoryStream);
      Assert.IsInstanceOfType(obj, typeof(DomException));
      DomException deserialized = (obj as DomException);
      Assert.AreEqual(deserialized.Message, domException.Message);
    }
  }
}
