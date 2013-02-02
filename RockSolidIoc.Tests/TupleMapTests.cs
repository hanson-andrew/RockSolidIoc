using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class TupleMapTests
  {
    [TestMethod]
    public void TestAddOrUpdate()
    {
      TupleMap<int, string, object> testMap = new TupleMap<int, string, object>();
      object firstObject = new object();
      testMap.AddOrUpdate(1, "test", firstObject);
      Assert.AreEqual(firstObject, testMap.GetMappedObject(1, "test"));
      object secondObject = new object();
      testMap.AddOrUpdate(1, "test", secondObject);
      object thirdObject = new object();
      testMap.AddOrUpdate(1, "third", thirdObject);
      Assert.AreEqual(secondObject, testMap.GetMappedObject(1, "test"));
      Assert.AreEqual(thirdObject, testMap.GetMappedObject(1, "third"));
    }

    [TestMethod]
    public void TestIsInMap()
    {
      TupleMap<int, string, object> testMap = new TupleMap<int, string, object>();
      testMap.AddOrUpdate(1, "test", new object());
      Assert.IsTrue(testMap.IsInMap(1, "test"));
      Assert.IsFalse(testMap.IsInMap(2, "test"));
      Assert.IsFalse(testMap.IsInMap(1, "no-test"));
      Assert.IsFalse(testMap.IsInMap(3, "not-here"));
    }

    [TestMethod]
    public void TestGetNonExistingItem()
    {
      TupleMap<int, string, object> testMap = new TupleMap<int, string, object>();
      try
      {
        testMap.GetMappedObject(1, "test");
        Assert.Fail();
      }
      catch (ArgumentException) { }
    }

    [TestMethod]
    public void TestDispose()
    {
      Mock<IDisposable> disposableKey1 = new Mock<IDisposable>();
      Mock<IDisposable> disposableKey2 = new Mock<IDisposable>();
      Mock<IDisposable> disposableMappedTo = new Mock<IDisposable>();

      TupleMap<object, object, object> testMap = new TupleMap<object, object, object>();
      testMap.AddOrUpdate(disposableKey1.Object, disposableKey2.Object, disposableMappedTo.Object);

      testMap.Dispose();
      disposableKey1.Verify(disposableObject => disposableObject.Dispose(), Times.Exactly(1));
      disposableKey2.Verify(disposableObject => disposableObject.Dispose(), Times.Exactly(1));
      disposableMappedTo.Verify(disposableObject => disposableObject.Dispose(), Times.Exactly(1));

      disposableKey1 = new Mock<IDisposable>();
      disposableKey2 = new Mock<IDisposable>();
      disposableMappedTo = new Mock<IDisposable>();

      testMap = new TupleMap<object, object, object>();
      testMap.AddOrUpdate(disposableKey1.Object, new object(), new object());
      testMap.AddOrUpdate(new object(), disposableKey2.Object, new object());
      testMap.AddOrUpdate(new object(), new object(), disposableMappedTo.Object);

      testMap.Dispose();
      disposableKey1.Verify(disposableObject => disposableObject.Dispose(), Times.Exactly(1));
      disposableKey2.Verify(disposableObject => disposableObject.Dispose(), Times.Exactly(1));
      disposableMappedTo.Verify(disposableObject => disposableObject.Dispose(), Times.Exactly(1));
    }
  }

}