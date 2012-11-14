using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class TupleMapTests
  {
    [Fact()]
    public void TestAddOrUpdate()
    {
      TupleMap<int, string, object> testMap = new TupleMap<int, string, object>();
      object firstObject = new object();
      testMap.AddOrUpdate(1, "test", firstObject);
      Assert.Equal(firstObject, testMap.GetMappedObject(1, "test"));
      object secondObject = new object();
      testMap.AddOrUpdate(1, "test", secondObject);
      object thirdObject = new object();
      testMap.AddOrUpdate(1, "third", thirdObject);
      Assert.Equal(secondObject, testMap.GetMappedObject(1, "test"));
      Assert.Equal(thirdObject, testMap.GetMappedObject(1, "third"));
    }

    [Fact()]
    public void TestIsInMap()
    {
      TupleMap<int, string, object> testMap = new TupleMap<int, string, object>();
      testMap.AddOrUpdate(1, "test", new object());
      Assert.True(testMap.IsInMap(1, "test"));
      Assert.False(testMap.IsInMap(2, "test"));
      Assert.False(testMap.IsInMap(1, "no-test"));
      Assert.False(testMap.IsInMap(3, "not-here"));
    }

    [Fact()]
    public void TestGetNonExistingItem()
    {
      TupleMap<int, string, object> testMap = new TupleMap<int, string, object>();
      Assert.Throws<ArgumentException>(delegate { testMap.GetMappedObject(1, "test"); });
    }

    [Fact()]
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