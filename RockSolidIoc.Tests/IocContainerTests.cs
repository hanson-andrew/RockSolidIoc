using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RockSolidIoc.Tests
{
  [TestClass]
  public class IocContainerTests
  {
    #region AddResolver Tests
    [TestMethod]
    public void TestAddDefaultResolverInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Mock<IResolver> mockResolver = new Mock<IResolver>();
      Type typeToResolve = typeof(object);
      testContainer.AddResolver(mockResolver.Object, typeToResolve);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, String.Empty, mockResolver.Object));
    }

    [TestMethod]
    public void TestAddNamedResolverInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Mock<IResolver> mockResolver = new Mock<IResolver>();
      Type typeToResolve = typeof(object);
      string identifier = "identifier";
      testContainer.AddResolver(mockResolver.Object, typeToResolve, identifier);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, identifier, mockResolver.Object));
    }

    [TestMethod]
    public void TestAddDefaultResolverType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type resolverType = typeof(ResolverImpl);
      Type typeToResolve = typeof(object);
      testContainer.AddResolver(resolverType, typeToResolve);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, String.Empty, resolverType));
    }

    [TestMethod]
    public void TestAddNamedResolverType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type resolverType = typeof(ResolverImpl);
      Type typeToResolve = typeof(object);
      string identifier = "identifier";
      testContainer.AddResolver(resolverType, typeToResolve, identifier);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, identifier, resolverType));
    }

    [TestMethod]
    public void TestAddDefaultResolverInstanceGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Mock<IResolver> resolver = new Mock<IResolver>();
      Type typeToResolve = typeof(object);
      testContainer.AddResolver<object>(resolver.Object);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, String.Empty, resolver.Object));
    }

    [TestMethod]
    public void TestAddNamedResolverInstanceGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Mock<IResolver> resolver = new Mock<IResolver>();
      Type typeToResolve = typeof(object);
      string identifier = "identifier";
      testContainer.AddResolver<object>(resolver.Object, identifier);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, identifier, resolver.Object));
    }

    [TestMethod]
    public void TestAddDefaultResolverTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type resolverType = typeof(ResolverImpl);
      Type typeToResolve = typeof(object);
      testContainer.AddResolver<ResolverImpl, object>();
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, String.Empty, resolverType));
    }

    [TestMethod]
    public void TestAddNamedResolverTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type resolverType = typeof(ResolverImpl);
      Type typeToResolve = typeof(object);
      string identifier = "identifier";
      testContainer.AddResolver<ResolverImpl, object>(identifier);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, identifier, resolverType));
    }
    #endregion

    [TestMethod]
    public void TestCreateChildContainerReturns()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);
      Assert.IsInstanceOfType(testContainer.CreateChildContainer(), typeof(IIocContainer));
    }

    #region LinkToLifetime Tests
    [TestMethod]
    public void TestDefaultLinkToManagerType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type managedType = typeof(object);
      Type managerType = typeof(ExternallyControlledLifetimeManager);
      testContainer.LinkToLifetime(managedType, managerType);
      mockManagerMap.Verify(map => map.AddOrUpdate(managedType, String.Empty, managerType));
    }

    [TestMethod]
    public void TestNamedLinkToManagerType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type managedType = typeof(object);
      Type managerType = typeof(ExternallyControlledLifetimeManager);
      string identifier = "identifier";
      testContainer.LinkToLifetime(managedType, managerType, identifier);
      mockManagerMap.Verify(map => map.AddOrUpdate(managedType, identifier, managerType));
    }

    [TestMethod]
    public void TestDefaultLinkToManagerInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type managedType = typeof(object);
      Mock<ILifetimeManager> managerMock = new Mock<ILifetimeManager>();
      testContainer.LinkToLifetime(managedType, managerMock.Object);
      mockManagerMap.Verify(map => map.AddOrUpdate(managedType, String.Empty, managerMock.Object));
    }

    [TestMethod]
    public void TestNamedLinkToManagerInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type managedType = typeof(object);
      Mock<ILifetimeManager> managerMock = new Mock<ILifetimeManager>();
      string identifier = "identifier";
      testContainer.LinkToLifetime(managedType, managerMock.Object, identifier);
      mockManagerMap.Verify(map => map.AddOrUpdate(managedType, identifier, managerMock.Object));
    }

    [TestMethod]
    public void TestDefaultGenericLinkToManagerInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type managedType = typeof(object);
      Mock<ILifetimeManager> managerMock = new Mock<ILifetimeManager>();
      testContainer.LinkToLifetime<object>(managerMock.Object);
      mockManagerMap.Verify(map => map.AddOrUpdate(managedType, String.Empty, managerMock.Object));
    }

    [TestMethod]
    public void TestNamedGenericLinkToManagerInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type managedType = typeof(object);
      Mock<ILifetimeManager> managerMock = new Mock<ILifetimeManager>();
      string identifer = "identifier";
      testContainer.LinkToLifetime<object>(managerMock.Object, identifer);
      mockManagerMap.Verify(map => map.AddOrUpdate(managedType, identifer, managerMock.Object));
    }

    [TestMethod]
    public void TestDefaultGenericLinkToManagerTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type managedType = typeof(object);
      Type managerType = typeof(ExternallyControlledLifetimeManager);
      testContainer.LinkToLifetime<object, ExternallyControlledLifetimeManager>();
      mockManagerMap.Verify(map => map.AddOrUpdate(managedType, String.Empty, managerType));
    }

    [TestMethod]
    public void TestNamedGenericLinkToManagerTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type managedType = typeof(object);
      Type managerType = typeof(ExternallyControlledLifetimeManager);
      string identifier = "identifier";
      testContainer.LinkToLifetime<object, ExternallyControlledLifetimeManager>(identifier);
      mockManagerMap.Verify(map => map.AddOrUpdate(managedType, identifier, managerType));
    }
    #endregion

    #region Register Tests
    [TestMethod]
    public void TestDefaultRegisterToType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type originalType = typeof(ISimpleInterface);
      Type mappedType = typeof(SimpleInterfaceImpl1);
      testContainer.RegisterType(originalType, mappedType);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, String.Empty, mappedType));
    }

    [TestMethod]
    public void TestNamedRegisterToType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type originalType = typeof(ISimpleInterface);
      Type mappedType = typeof(SimpleInterfaceImpl1);
      string identifier = "identifier";
      testContainer.RegisterType(originalType, mappedType, identifier);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, identifier, mappedType));
    }

    [TestMethod]
    public void TestDefaultGenericLinkToType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type originalType = typeof(ISimpleInterface);
      Type mappedType = typeof(SimpleInterfaceImpl1);
      testContainer.RegisterType<ISimpleInterface>(mappedType);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, String.Empty, mappedType));
    }

    [TestMethod]
    public void TestNamedGenericLinkToType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type originalType = typeof(ISimpleInterface);
      Type mappedType = typeof(SimpleInterfaceImpl1);
      string identifier = "identifier";
      testContainer.RegisterType<ISimpleInterface>(mappedType, identifier);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, identifier, mappedType));
    }

    [TestMethod]
    public void TestDefaultGenericLinkToInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type originalType = typeof(ISimpleInterface);
      Mock<ISimpleInterface> mockedSimpleInterface = new Mock<ISimpleInterface>();
      mockRegistrationChain.Setup(chain => chain.PickRegistration(originalType, String.Empty)).Returns(mockedSimpleInterface.Object.GetType());
      testContainer.RegisterType<ISimpleInterface>(mockedSimpleInterface.Object);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, String.Empty, mockedSimpleInterface.Object.GetType()));
      Assert.AreEqual(mockedSimpleInterface.Object, testContainer.Resolve<ISimpleInterface>());
    }

    [TestMethod]
    public void TestNamedGenericLinkToInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type originalType = typeof(ISimpleInterface);
      Mock<ISimpleInterface> mockedSimpleInterface = new Mock<ISimpleInterface>();
      string identifer = "identifier";
      mockRegistrationChain.Setup(chain => chain.PickRegistration(originalType, identifer)).Returns(mockedSimpleInterface.Object.GetType());
      testContainer.RegisterType<ISimpleInterface>(mockedSimpleInterface.Object, identifer);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, identifer, mockedSimpleInterface.Object.GetType()));
      Assert.AreEqual(mockedSimpleInterface.Object, testContainer.Resolve<ISimpleInterface>(identifer));
    }

    [TestMethod]
    public void TestDefaultGenericLinkToTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type originalType = typeof(ISimpleInterface);
      Type mappedType = typeof(SimpleInterfaceImpl1);
      testContainer.RegisterType<ISimpleInterface, SimpleInterfaceImpl1>();
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, String.Empty, mappedType));
    }

    [TestMethod]
    public void TestNamedGenericLinkToTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IResolverMap> mockResolverMap = new Mock<IResolverMap>();
      Mock<FindResolverStrategy> mockResolverChain = new Mock<FindResolverStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Type originalType = typeof(ISimpleInterface);
      Type mappedType = typeof(SimpleInterfaceImpl1);
      string identifier = "identifier";
      testContainer.RegisterType<ISimpleInterface, SimpleInterfaceImpl1>(identifier);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, identifier, mappedType));
    }
    #endregion

  }

}