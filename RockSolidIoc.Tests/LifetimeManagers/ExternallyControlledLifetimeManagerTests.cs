using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ExternallyControlledLifetimeManagerTests
  {
    [TestMethod]
    public void TestAddRetrieve()
    {
      ExternallyControlledLifetimeManager manager = new ExternallyControlledLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      Assert.AreEqual(disposable.Object, manager.GetInstance());
    }

    [TestMethod]
    public void TestRemoveInstance()
    {
      ExternallyControlledLifetimeManager manager = new ExternallyControlledLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.RemoveInstance();
      disposable.Verify(p => p.Dispose(), Times.Never());
      disposable.Object.Dispose();
      Assert.AreEqual(disposable.Object, manager.GetInstance());
    }

    [TestMethod]
    public void TestDispose()
    {
      ExternallyControlledLifetimeManager manager = new ExternallyControlledLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.Dispose();
      disposable.Verify(p => p.Dispose(), Times.Never());
    }
  }

}
