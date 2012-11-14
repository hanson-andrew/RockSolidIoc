using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class ContainerManagedLifetimeManagerTests
  {
    [Fact()]
    public void TestAddRetrieve()
    {
      ContainerManagedLifetimeManager manager = new ContainerManagedLifetimeManager();
      object o = new object();
      manager.AddInstance(o);
      Assert.Equal(o, manager.GetInstance());
    }

    [Fact()]
    public void TestRemoveInstance()
    {
      ContainerManagedLifetimeManager manager = new ContainerManagedLifetimeManager();
      object o = new object();
      manager.AddInstance(o);
      manager.RemoveInstance();
      Assert.Null(manager.GetInstance());
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.RemoveInstance();
      disposable.Verify(p => p.Dispose(), Times.Exactly(1));
    }

    [Fact()]
    public void TestDispose()
    {
      ContainerManagedLifetimeManager manager = new ContainerManagedLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.Dispose();
      disposable.Verify(p => p.Dispose(), Times.Exactly(1));
    }

    [Fact()]
    public void TestObjectDisposed()
    {
      ContainerManagedLifetimeManager manager = new ContainerManagedLifetimeManager();
      manager.Dispose();
      Assert.Throws<ObjectDisposedException>(delegate { manager.AddInstance(new object()); });
      Assert.Throws<ObjectDisposedException>(delegate { manager.AddInstance(new object()); });
      Assert.Throws<ObjectDisposedException>(delegate { manager.GetInstance(); });
      Assert.Throws<ObjectDisposedException>(delegate { manager.RemoveInstance(); });
      Assert.Throws<ObjectDisposedException>(delegate { manager.Dispose(); });
    }
  }

}