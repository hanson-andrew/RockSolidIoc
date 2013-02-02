using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class TransientLifetimeManagerTests
  {
    [TestMethod]
    public void TestAddRetrieve()
    {
      TransientLifetimeManager manager = new TransientLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      Assert.IsNull(manager.GetInstance());
    }

    [TestMethod]
    public void TestRemoveInstance()
    {
      TransientLifetimeManager manager = new TransientLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.RemoveInstance();
      disposable.Verify(p => p.Dispose(), Times.Never());
      Assert.IsNull(manager.GetInstance());
    }

    [TestMethod]
    public void TestDispose()
    {
      TransientLifetimeManager manager = new TransientLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.Dispose();
      disposable.Verify(p => p.Dispose(), Times.Never());
    }
  }

}