using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class ExternallyControlledLifetimeManagerTests
  {
    [Fact()]
    public void TestAddRetrieve()
    {
      ExternallyControlledLifetimeManager manager = new ExternallyControlledLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      Assert.Equal(disposable.Object, manager.GetInstance());
    }

    [Fact()]
    public void TestRemoveInstance()
    {
      ExternallyControlledLifetimeManager manager = new ExternallyControlledLifetimeManager();
      Mock<IDisposable> disposable = new Mock<IDisposable>();
      manager.AddInstance(disposable.Object);
      manager.RemoveInstance();
      disposable.Verify(p => p.Dispose(), Times.Never());
      disposable.Object.Dispose();
      Assert.Equal(disposable.Object, manager.GetInstance());
    }

    [Fact()]
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
