using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ContainerManagedLifetimeManagerTests
  {
    [TestMethod]
    public void TestAddRetrieve()
    {
      ContainerManagedLifetimeManager manager = new ContainerManagedLifetimeManager();
      object o = new object();
      manager.AddInstance(o);
      Assert.AreEqual(o, manager.GetInstance());
    }

    [TestMethod]
    public void TestRemoveInstance()
    {
      ContainerManagedLifetimeManager manager = new ContainerManagedLifetimeManager();
      object o = new object();
      manager.AddInstance(o);
      manager.RemoveInstance();
      Assert.IsNull(manager.GetInstance());
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.RemoveInstance();
      disposable.Verify(p => p.Dispose(), Times.Exactly(1));
    }

    [TestMethod]
    public void TestDispose()
    {
      ContainerManagedLifetimeManager manager = new ContainerManagedLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.Dispose();
      disposable.Verify(p => p.Dispose(), Times.Exactly(1));
    }

    [TestMethod]
    public void TestObjectDisposed()
    {
      ContainerManagedLifetimeManager manager = new ContainerManagedLifetimeManager();
      manager.Dispose();
      try
      {
        manager.AddInstance(new object());
        Assert.Fail();
      }
      catch (ObjectDisposedException)
      { }
      try
      {
        manager.GetInstance();
        Assert.Fail();
      }
      catch (ObjectDisposedException)
      { }
      try
      {
        manager.RemoveInstance();
        Assert.Fail();
      }
      catch (ObjectDisposedException)
      { }
      try
      {
        manager.Dispose();
        Assert.Fail();
      }
      catch (ObjectDisposedException)
      { }
    }
  }

}