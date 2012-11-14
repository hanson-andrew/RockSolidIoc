using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class ResolverTests
  {
    [Fact()]
    public void TestMultipleIocConstructorAttributes()
    {
      DefaultInstantiator r = new DefaultInstantiator();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      Assert.Throws<IocException>(delegate { r.ResolveDependency(typeof(BadConstructorAttributes), context.Object); });
    }

    [Fact()]
    public void TestMultipleConstructorsOfMaxSize()
    {
      DefaultInstantiator r = new DefaultInstantiator();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      Assert.Throws<IocException>(delegate { r.ResolveDependency(typeof(MatchingConstructorCounts), context.Object); });
    }

    [Fact()]
    public void TestStandardConstruction()
    {
      DefaultInstantiator r = new DefaultInstantiator();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      object returnedObject = new object();
      string returnedString = "returnedString";
      int returnedInt = 300;
      context.Setup((c) => c.Resolve(typeof(object), String.Empty)).Returns(returnedObject);
      context.Setup((c) => c.Resolve(typeof(string), String.Empty)).Returns(returnedString);
      context.Setup((c) => c.Resolve(typeof(int), String.Empty)).Returns(returnedInt);
      StandardConstruction result = (r.ResolveDependency(typeof(StandardConstruction), context.Object) as StandardConstruction);
      Assert.Equal(returnedObject, result.O);
      Assert.Equal(returnedString, result.S);
      Assert.Equal(returnedInt, result.I);
    }

    [Fact()]
    public void TestPropertyAndMethodSetup()
    {
      DefaultInstantiator r = new DefaultInstantiator();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      object returnedObject = new object();
      string returnedString = "returnedString";
      context.Setup((c) => c.Resolve(typeof(object), String.Empty)).Returns(returnedObject);
      context.Setup((c) => c.Resolve(typeof(string), String.Empty)).Returns(returnedString);
      PropertyAndMethodInitialization result = (r.ResolveDependency(typeof(PropertyAndMethodInitialization), context.Object) as PropertyAndMethodInitialization);
      Assert.Equal(returnedObject, result.O);
      Assert.Equal(returnedString, result.S);
    }

    [Fact()]
    public void TestIdentifiedParemeterResolution()
    {
      DefaultInstantiator r = new DefaultInstantiator();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      object returnedObject = new object();
      string basicString = "basicString";
      string returnedString = "returnedString";
      int returnedInt = 300;
      context.Setup((c) => c.Resolve(typeof(object), String.Empty)).Returns(returnedObject);
      context.Setup((c) => c.Resolve(typeof(string), String.Empty)).Returns(basicString);
      context.Setup((c) => c.Resolve(typeof(string), StandardIdentifierConstruction.TestingIdentifier)).Returns(returnedString);
      context.Setup((c) => c.Resolve(typeof(int), String.Empty)).Returns(returnedInt);
      StandardIdentifierConstruction result = (StandardIdentifierConstruction)r.ResolveDependency(typeof(StandardIdentifierConstruction), context.Object);
      Assert.Equal(returnedObject, result.O);
      Assert.Equal(returnedString, result.S);
      Assert.Equal(returnedInt, result.I);
    }

    [Fact()]
    public void TestUnresolvableThrowsException()
    {
      DefaultInstantiator r = new DefaultInstantiator();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      context.Setup(a => a.Resolve(typeof(IDisposable), String.Empty)).Callback(() =>
      {
        throw new IocException();
      });
      Assert.Throws<IocException>(delegate { r.ResolveDependency(typeof(UnresolvableParameter), context.Object); });
    }

    [Fact()]
    public void TestResolvingInterfaceThrowsException()
    {
      DefaultInstantiator r = new DefaultInstantiator();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      context.Setup(a => a.Resolve(typeof(IDisposable), String.Empty)).Callback(() =>
      {
        throw new IocException();
      });
      Assert.Throws<IocException>(delegate { r.ResolveDependency(typeof(IDisposable), context.Object); });
    }
  }

}