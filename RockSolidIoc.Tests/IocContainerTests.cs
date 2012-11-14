using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

namespace RockSolidIoc.Tests
{

  public class IocContainerTests
  {
    #region AddResolver Tests
    [Fact()]
    public void TestAddDefaultResolverInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Mock<IInstantiator> mockResolver = new Mock<IInstantiator>();
      Type typeToResolve = typeof(object);
      testContainer.AddInstantiator(mockResolver.Object, typeToResolve);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, String.Empty, mockResolver.Object));
    }

    [Fact()]
    public void TestAddNamedResolverInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Mock<IInstantiator> mockResolver = new Mock<IInstantiator>();
      Type typeToResolve = typeof(object);
      string identifier = "identifier";
      testContainer.AddInstantiator(mockResolver.Object, typeToResolve, identifier);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, identifier, mockResolver.Object));
    }

    [Fact()]
    public void TestAddDefaultResolverType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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
      testContainer.AddInstantiator(resolverType, typeToResolve);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, String.Empty, resolverType));
    }

    [Fact()]
    public void TestAddNamedResolverType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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
      testContainer.AddInstantiator(resolverType, typeToResolve, identifier);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, identifier, resolverType));
    }

    [Fact()]
    public void TestAddDefaultResolverInstanceGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Mock<IInstantiator> resolver = new Mock<IInstantiator>();
      Type typeToResolve = typeof(object);
      testContainer.AddInstantiator<object>(resolver.Object);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, String.Empty, resolver.Object));
    }

    [Fact()]
    public void TestAddNamedResolverInstanceGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);

      Mock<IInstantiator> resolver = new Mock<IInstantiator>();
      Type typeToResolve = typeof(object);
      string identifier = "identifier";
      testContainer.AddInstantiator<object>(resolver.Object, identifier);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, identifier, resolver.Object));
    }

    [Fact()]
    public void TestAddDefaultResolverTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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
      testContainer.AddInstantiator<ResolverImpl, object>();
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, String.Empty, resolverType));
    }

    [Fact()]
    public void TestAddNamedResolverTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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
      testContainer.AddInstantiator<ResolverImpl, object>(identifier);
      mockResolverMap.Verify(map => map.AddOrUpdate(typeToResolve, identifier, resolverType));
    }
    #endregion

    [Fact()]
    public void TestCreateChildContainerReturns()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
      Mock<ILifetimeManagerMap> mockManagerMap = new Mock<ILifetimeManagerMap>();
      Mock<FindLifetimeManagerStrategy> mockManagerChain = new Mock<FindLifetimeManagerStrategy>();

      IocContainer testContainer = new IocContainer(mockRegistrationMap.Object,
                                                    mockRegistrationChain.Object,
                                                    mockResolverMap.Object,
                                                    mockResolverChain.Object,
                                                    mockManagerMap.Object,
                                                    mockManagerChain.Object);
      Assert.IsAssignableFrom<IIocContainer>(testContainer.CreateChildContainer());
    }

    #region LinkToLifetime Tests
    [Fact()]
    public void TestDefaultLinkToManagerType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestNamedLinkToManagerType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestDefaultLinkToManagerInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestNamedLinkToManagerInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestDefaultGenericLinkToManagerInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestNamedGenericLinkToManagerInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestDefaultGenericLinkToManagerTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestNamedGenericLinkToManagerTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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
    [Fact()]
    public void TestDefaultRegisterToType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestNamedRegisterToType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestDefaultGenericLinkToType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestNamedGenericLinkToType()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestDefaultGenericLinkToInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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
      mockRegistrationChain.Setup(chain => chain.PickRegistration(mockRegistrationMap.Object, originalType, String.Empty)).Returns(mockedSimpleInterface.Object.GetType());
      testContainer.RegisterType<ISimpleInterface>(mockedSimpleInterface.Object);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, String.Empty, mockedSimpleInterface.Object.GetType()));
      Assert.Equal(mockedSimpleInterface.Object, testContainer.Resolve<ISimpleInterface>());
    }

    [Fact()]
    public void TestNamedGenericLinkToInstance()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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
      mockRegistrationChain.Setup(chain => chain.PickRegistration(mockRegistrationMap.Object, originalType, identifer)).Returns(mockedSimpleInterface.Object.GetType());
      testContainer.RegisterType<ISimpleInterface>(mockedSimpleInterface.Object, identifer);
      mockRegistrationMap.Verify(map => map.AddOrUpdate(originalType, identifer, mockedSimpleInterface.Object.GetType()));
      Assert.Equal(mockedSimpleInterface.Object, testContainer.Resolve<ISimpleInterface>(identifer));
    }

    [Fact()]
    public void TestDefaultGenericLinkToTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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

    [Fact()]
    public void TestNamedGenericLinkToTypeGenerically()
    {
      Mock<IRegistrationMap> mockRegistrationMap = new Mock<IRegistrationMap>();
      Mock<PickRegistrationStrategy> mockRegistrationChain = new Mock<PickRegistrationStrategy>();
      Mock<IInstantiatorMap> mockResolverMap = new Mock<IInstantiatorMap>();
      Mock<FindInstantiatorStrategy> mockResolverChain = new Mock<FindInstantiatorStrategy>();
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