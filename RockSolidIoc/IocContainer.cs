using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public class IocContainer : IIocContainer
  {

    private bool _disposedValue;

    private IocContainer _parent;
    private ICollection<IIocContainer> _childContainers = new List<IIocContainer>();

    private IRegistrationMap _registrationMap;
    private PickRegistrationStrategy _registrationChain;

    private IInstantiatorMap _instantiatorMap;
    private FindInstantiatorStrategy _instantiationChain;

    private ILifetimeManagerMap _lifetimeManagerMap;
    private FindLifetimeManagerStrategy _lifetimeChain;

    private TupleMap<Type, string, ILifetimeManager> _resolutions = new TupleMap<Type, string, ILifetimeManager>();

    public IocContainer() : this(null) { }

    private IocContainer(IocContainer parent)
    {
      this._parent = parent;
      if (parent != null)
      {
        this._registrationChain = ChainBuilder<PickRegistrationStrategy>.Build(new RegistrationInMapStrategyImpl()).WithNextStep(parent.RegistrationChain);
        this._instantiationChain = ChainBuilder<FindInstantiatorStrategy>.Build(new InstantiatorInMapStrategyImpl()).WithNextStep(parent.InstantiatorChain);
        this._lifetimeChain = ChainBuilder<FindLifetimeManagerStrategy>.Build(new ManagerInMapStrategyImpl()).WithNextStep(parent.LifetimeChain);
      }
      else
      {
        this._registrationChain = ChainBuilder<PickRegistrationStrategy>.Build(new RegistrationInMapStrategyImpl()).WithNextStep(new MapToAttributeStrategyImpl()).WithNextStep(new OneImplementationStrategyImpl()).WithNextStep(new SimpleObjectStrategyImpl()).WithNextStep(new RegistrationNotFoundStrategyImpl());
        this._instantiationChain = ChainBuilder<FindInstantiatorStrategy>.Build(new InstantiatorInMapStrategyImpl()).WithNextStep(new UseInstantiatorAttributeStrategyImpl()).WithNextStep(new UseDefaultInstantiatorStrategyImpl());
        this._lifetimeChain = ChainBuilder<FindLifetimeManagerStrategy>.Build(new ManagerInMapStrategyImpl()).WithNextStep(new UseLifetimeManagerAttributeStrategyImpl()).WithNextStep(new UseDefaultLifetimeManagerStrategyImpl());
      }
      this._registrationMap = new RegistrationMap();
      this._instantiatorMap = new InstantiatorMap();
      this._lifetimeManagerMap = new LifetimeManagerMap();
    }

    public IocContainer(IRegistrationMap registrationMap,
                        PickRegistrationStrategy registrationChain,
                        IInstantiatorMap resolverMap,
                        FindInstantiatorStrategy resolverChain,
                        ILifetimeManagerMap lifetimeManagerMap,
                        FindLifetimeManagerStrategy lifetimeChain)
      : this(null, registrationMap, registrationChain, resolverMap, resolverChain, lifetimeManagerMap, lifetimeChain) { }

    private IocContainer(IocContainer parent,
                         IRegistrationMap registrationMap,
                         PickRegistrationStrategy registrationChain,
                         IInstantiatorMap resolverMap,
                         FindInstantiatorStrategy resolverChain,
                         ILifetimeManagerMap lifetimeManagerMap,
                         FindLifetimeManagerStrategy lifetimeChain)
    {
      this._parent = parent;
      this._registrationChain = registrationChain;
      this._registrationMap = registrationMap;
      this._instantiationChain = resolverChain;
      this._instantiatorMap = resolverMap;
      this._lifetimeChain = lifetimeChain;
      this._lifetimeManagerMap = lifetimeManagerMap;
    }

    private PickRegistrationStrategy RegistrationChain
    {
      get
      {
        return this._registrationChain;
      }
    }

    private FindInstantiatorStrategy InstantiatorChain
    {
      get
      {
        return this._instantiationChain;
      }
    }

    private FindLifetimeManagerStrategy LifetimeChain
    {
      get
      {
        return this._lifetimeChain;
      }
    }

    public void AddInstantiator(IInstantiator instantiator, Type toCreate)
    {
      this.AddTypeAgnostingInstantiator(instantiator, toCreate, string.Empty);
    }

    public void AddInstantiator(IInstantiator instantiator, Type toCreate, string identifier)
    {
      this.AddTypeAgnostingInstantiator(instantiator, toCreate, identifier);
    }

    public void AddInstantiator(Type instantiator, Type toCreate)
    {
      this.AddTypeAgnostingInstantiator(instantiator, toCreate, string.Empty);
    }

    public void AddInstantiator(Type instantiator, Type toCreate, string identifier)
    {
      this.AddTypeAgnostingInstantiator(instantiator, toCreate, identifier);
    }

    public void AddInstantiator<TSolution>(IInstantiator instantiator)
    {
      this.AddTypeAgnostingInstantiator(instantiator, typeof(TSolution).UnderlyingSystemType, string.Empty);
    }

    public void AddInstantiator<TSolution>(IInstantiator instantiator, string identifier)
    {
      this.AddTypeAgnostingInstantiator(instantiator, typeof(TSolution).UnderlyingSystemType, identifier);
    }

    public void AddInstantiator<TInstantiator, TSolution>()
    {
      this.AddTypeAgnostingInstantiator(typeof(TInstantiator).UnderlyingSystemType, typeof(TSolution).UnderlyingSystemType, string.Empty);
    }

    public void AddInstantiator<TInstantiator, TSolution>(string identifier)
    {
      this.AddTypeAgnostingInstantiator(typeof(TInstantiator).UnderlyingSystemType, typeof(TSolution).UnderlyingSystemType, identifier);
    }

    private void AddTypeAgnostingInstantiator(object instantiator, Type toCreate, string identifier)
    {
      this._instantiatorMap.AddOrUpdate(toCreate, identifier, instantiator);
    }

    public IIocContainer CreateChildContainer()
    {
      IocContainer childContainer = new IocContainer(this);
      this._childContainers.Add(childContainer);
      return childContainer;
    }

    public void LinkToLifetime(Type type, Type lifetimeManager)
    {
      this.LinkToLifetimeTypeAgnostic(type, string.Empty, lifetimeManager);
    }

    public void LinkToLifetime(Type type, Type lifetimeManager, string identifier)
    {
      this.LinkToLifetimeTypeAgnostic(type, identifier, lifetimeManager);
    }

    public void LinkToLifetime(Type type, ILifetimeManager lifetimeManager)
    {
      this.LinkToLifetimeTypeAgnostic(type, string.Empty, lifetimeManager);
    }

    public void LinkToLifetime(Type type, ILifetimeManager lifetimeManager, string identifier)
    {
      this.LinkToLifetimeTypeAgnostic(type, identifier, lifetimeManager);
    }

    public void LinkToLifetime<T>(ILifetimeManager lifetimeManager)
    {
      this.LinkToLifetimeTypeAgnostic(typeof(T).UnderlyingSystemType, string.Empty, lifetimeManager);
    }

    public void LinkToLifetime<T>(ILifetimeManager lifetimeManager, string identifier)
    {
      this.LinkToLifetimeTypeAgnostic(typeof(T).UnderlyingSystemType, identifier, lifetimeManager);
    }

    public void LinkToLifetime<T, TLifetimeManager>() where TLifetimeManager : ILifetimeManager
    {
      this.LinkToLifetimeTypeAgnostic(typeof(T).UnderlyingSystemType, string.Empty, typeof(TLifetimeManager).UnderlyingSystemType);
    }

    public void LinkToLifetime<T, TLifetimeManager>(string identifier) where TLifetimeManager : ILifetimeManager
    {
      this.LinkToLifetimeTypeAgnostic(typeof(T).UnderlyingSystemType, identifier, typeof(TLifetimeManager).UnderlyingSystemType);
    }

    private void LinkToLifetimeTypeAgnostic(Type type, string identifier, object lifetimeManager)
    {
      this._lifetimeManagerMap.AddOrUpdate(type, identifier, lifetimeManager);
    }

    public void RegisterType(Type original, Type implementation)
    {
      this.RegisterTypeAgnostic(original, implementation, string.Empty);
    }

    public void RegisterType(Type original, Type implementation, string identifier)
    {
      this.RegisterTypeAgnostic(original, implementation, identifier);
    }

    public void RegisterType<T>(Type implementation)
    {
      this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, implementation, string.Empty);
    }

    public void RegisterType<T>(Type implementation, string identifier)
    {
      this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, implementation, identifier);
    }

    public void RegisterType<T>(T instance)
    {
      this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, instance, string.Empty);
    }

    public void RegisterType<T>(T instance, string identifier)
    {
      this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, instance, identifier);
    }

    public void RegisterType<T, TImplemented>() where TImplemented : T
    {
      this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, typeof(TImplemented).UnderlyingSystemType, string.Empty);
    }

    public void RegisterType<T, TImplemented>(string identifier) where TImplemented : T
    {
      this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, typeof(TImplemented).UnderlyingSystemType, identifier);
    }

    private void RegisterTypeAgnostic(Type original, object implementation, string identifier)
    {
      if (implementation is Type)
      {
        this._registrationMap.AddOrUpdate(original, identifier, (implementation as Type));
      }
      else
      {
        this._registrationMap.AddOrUpdate(original, identifier, implementation.GetType());
        ContainerManagedLifetimeManager lifetimeManager = new ContainerManagedLifetimeManager();
        lifetimeManager.AddInstance(implementation);
        this._resolutions.AddOrUpdate(implementation.GetType(), identifier, lifetimeManager);
      }
    }

    public T Resolve<T>()
    {
      return (T)this.Resolve(typeof(T).UnderlyingSystemType, string.Empty, string.Empty, string.Empty);
    }

    public T Resolve<T>(string identifier)
    {
      return (T)this.Resolve(typeof(T).UnderlyingSystemType, identifier, identifier, identifier);
    }

    public T Resolve<T>(string registrationIdentifier, string resolutionIdentifier, string lifetimeIdentifier)
    {
      return (T)this.Resolve(typeof(T).UnderlyingSystemType, registrationIdentifier, resolutionIdentifier, lifetimeIdentifier);
    }

    public object Resolve(Type type)
    {
      return this.Resolve(type, string.Empty, string.Empty, string.Empty);
    }

    public object Resolve(Type type, string identifier)
    {
      return this.Resolve(type, identifier, identifier, identifier);
    }

    private ILifetimeManager GetPreviousResolution(Type type, string lifetimeIdentifier)
    {
      if (this._resolutions.IsInMap(type, lifetimeIdentifier))
      {
        return this._resolutions.GetMappedObject(type, lifetimeIdentifier);
      }
      else if (this._parent != null)
      {
        return this._parent.GetPreviousResolution(type, lifetimeIdentifier);
      }
      return null;
    }

    public object Resolve(Type type, string registrationIdentifier, string resolutionIdentifier, string lifetimeIdentifier)
    {
      if (typeof(IIocContainer).Equals(type))
      {
        return this;
      }
      if (this.GetType().Equals(type))
      {
        return this;
      }

      object instance = null;

      Type mappedType = (Type)this._registrationChain.PickRegistration(this._registrationMap, type, registrationIdentifier);

      ILifetimeManager lifetimeManager = this.GetPreviousResolution(mappedType, lifetimeIdentifier);

      if (lifetimeManager != null)
      {
        instance = lifetimeManager.GetInstance();
        if (instance != null)
        {
          return instance;
        }
      }

      IInstantiator instantiator;
      object unboxedInstantiator = this._instantiationChain.FindInstantiator(this._instantiatorMap, type, resolutionIdentifier);
      if (unboxedInstantiator is Type)
      {
        instantiator = (IInstantiator)this.Resolve((Type)unboxedInstantiator);
      }
      else
      {
        instantiator = (unboxedInstantiator as IInstantiator);
      }

      var unboxedLifetimeManager = this._lifetimeChain.FindLifetimeManager(this._lifetimeManagerMap, type, lifetimeIdentifier);
      if (unboxedLifetimeManager is Type)
      {
        lifetimeManager = (ILifetimeManager)this.Resolve((Type)unboxedLifetimeManager);
      }
      else
      {
        lifetimeManager = (unboxedLifetimeManager as ILifetimeManager);
      }

      instance = instantiator.ResolveDependency(mappedType, this);
      lifetimeManager.AddInstance(instance);
      this._resolutions.AddOrUpdate(mappedType, lifetimeIdentifier, lifetimeManager);

      return instance;
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposedValue)
      {
        if (disposing)
        {
          this._instantiatorMap.Dispose();
          this._lifetimeManagerMap.Dispose();
          this._registrationMap.Dispose();
          this._resolutions.Dispose();
        }
      }
      this._disposedValue = true;
    }

    public virtual void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

  }
}