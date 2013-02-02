using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class ResolverTests
  {
    [TestMethod]
    public void TestMultipleIocConstructorAttributes()
    {
      Resolver r = new Resolver();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      try
      {
        r.ResolveDependency(typeof(BadConstructorAttributes), context.Object);
        Assert.Fail();
      }
      catch (IocException) { }
    }

    [TestMethod]
    public void TestMultipleConstructorsOfMaxSize()
    {
      Resolver r = new Resolver();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      try
      {
        r.ResolveDependency(typeof(MatchingConstructorCounts), context.Object);
        Assert.Fail();
      }
      catch (IocException) { }
    }

    [TestMethod]
    public void TestStandardConstruction()
    {
      Resolver r = new Resolver();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      object returnedObject = new object();
      string returnedString = "returnedString";
      int returnedInt = 300;
      context.Setup((c) => c.Resolve(typeof(object), String.Empty)).Returns(returnedObject);
      context.Setup((c) => c.Resolve(typeof(string), String.Empty)).Returns(returnedString);
      context.Setup((c) => c.Resolve(typeof(int), String.Empty)).Returns(returnedInt);
      StandardConstruction result = (r.ResolveDependency(typeof(StandardConstruction), context.Object) as StandardConstruction);
      Assert.AreEqual(returnedObject, result.O);
      Assert.AreEqual(returnedString, result.S);
      Assert.AreEqual(returnedInt, result.I);
    }

    [TestMethod]
    public void TestPropertyAndMethodSetup()
    {
      Resolver r = new Resolver();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      object returnedObject = new object();
      string returnedString = "returnedString";
      context.Setup((c) => c.Resolve(typeof(object), String.Empty)).Returns(returnedObject);
      context.Setup((c) => c.Resolve(typeof(string), String.Empty)).Returns(returnedString);
      PropertyAndMethodInitialization result = (r.ResolveDependency(typeof(PropertyAndMethodInitialization), context.Object) as PropertyAndMethodInitialization);
      Assert.AreEqual(returnedObject, result.O);
      Assert.AreEqual(returnedString, result.S);
    }

    [TestMethod]
    public void TestIdentifiedParemeterResolution()
    {
      Resolver r = new Resolver();
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
      Assert.AreEqual(returnedObject, result.O);
      Assert.AreEqual(returnedString, result.S);
      Assert.AreEqual(returnedInt, result.I);
    }

    [TestMethod]
    public void TestUnresolvableThrowsException()
    {
      Resolver r = new Resolver();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      context.Setup(a => a.Resolve(typeof(IDisposable), String.Empty)).Callback(() =>
      {
        throw new IocException();
      });
      try
      {
        r.ResolveDependency(typeof(UnresolvableParameter), context.Object);
        Assert.Fail();
      }
      catch (IocException) { }
    }

    [TestMethod]
    public void TestResolvingInterfaceThrowsException()
    {
      Resolver r = new Resolver();
      Mock<IIocContainer> context = new Mock<IIocContainer>();
      context.Setup(a => a.Resolve(typeof(IDisposable), String.Empty)).Callback(() =>
      {
        throw new IocException();
      });
      try
      {
        r.ResolveDependency(typeof(IDisposable), context.Object);
        Assert.Fail();
      }
      catch (IocException) { }
    }
  }

}