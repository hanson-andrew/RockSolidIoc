using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class TransientLifetimeManagerTests
  {
    [Fact()]
    public void TestAddRetrieve()
    {
      TransientLifetimeManager manager = new TransientLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      Assert.Null(manager.GetInstance());
    }

    [Fact()]
    public void TestRemoveInstance()
    {
      TransientLifetimeManager manager = new TransientLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.RemoveInstance();
      disposable.Verify(p => p.Dispose(), Times.Never());
      Assert.Null(manager.GetInstance());
    }

    [Fact()]
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