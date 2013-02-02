using System;
using System.Collections.Generic;

namespace RockSolidIoc
{

	public class IocContainer : IIocContainer
	{


		private bool _disposedValue = false;
		private IocContainer _parent;

		private ICollection<IIocContainer> _childContainers = new List<IIocContainer>();
		private IRegistrationMap _registrationMap;

		private PickRegistrationStrategy _registrationChain;
		private IResolverMap _resolverMap;

		private FindResolverStrategy _resolverChain;
		private ILifetimeManagerMap _lifetimeManagerMap;

		private FindLifetimeManagerStrategy _lifetimeChain;

		private TupleMap<Type, string, ILifetimeManager> _resolutions = new TupleMap<Type, string, ILifetimeManager>();
		public IocContainer() : this(null)
		{
		}

		private IocContainer(IocContainer parent)
		{
			this._parent = parent;
			if ((parent != null)) {
				this._registrationChain = ChainBuilder<PickRegistrationStrategy>.Build(new RegistrationInMapStrategyImpl(() => this._registrationMap)).WithNextStep(parent.RegistrationChain);
				this._resolverChain = ChainBuilder<FindResolverStrategy>.Build(new ResolverInMapStrategyImpl(() => this._resolverMap)).WithNextStep(parent.ResolverChain);
				this._lifetimeChain = ChainBuilder<FindLifetimeManagerStrategy>.Build(new ManagerInMapStrategyImpl(() => this._lifetimeManagerMap)).WithNextStep(parent.LifetimeChain);
			} else {
				this._registrationChain = ChainBuilder<PickRegistrationStrategy>.Build(new RegistrationInMapStrategyImpl(() => this._registrationMap)).WithNextStep(new MapToAttributeStrategyImpl()).WithNextStep(new OneImplementationStrategyImpl()).WithNextStep(new SimpleObjectStrategyImpl()).WithNextStep(new RegistrationNotFoundStrategyImpl());
				this._resolverChain = ChainBuilder<FindResolverStrategy>.Build(new ResolverInMapStrategyImpl(() => this._resolverMap)).WithNextStep(new UseResolverAttributeStrategyImpl()).WithNextStep(new UseDefaultResolverStrategyImpl());
				this._lifetimeChain = ChainBuilder<FindLifetimeManagerStrategy>.Build(new ManagerInMapStrategyImpl(() => this._lifetimeManagerMap)).WithNextStep(new UseLifetimeManagerAttributeStrategyImpl()).WithNextStep(new UseDefaultLifetimeManagerStrategyImpl());
			}
			this._registrationMap = new RegistrationMap();
			this._resolverMap = new ResolverMap();
			this._lifetimeManagerMap = new LifetimeManagerMap();
		}

		public IocContainer(IRegistrationMap registrationMap, PickRegistrationStrategy registrationChain, IResolverMap resolverMap, FindResolverStrategy resolverChain, ILifetimeManagerMap lifetimeManagerMap, FindLifetimeManagerStrategy lifetimeChain) : this(null, registrationMap, registrationChain, resolverMap, resolverChain, lifetimeManagerMap, lifetimeChain)
		{
		}

		private IocContainer(IocContainer parent, IRegistrationMap registrationMap, PickRegistrationStrategy registrationChain, IResolverMap resolverMap, FindResolverStrategy resolverChain, ILifetimeManagerMap lifetimeManagerMap, FindLifetimeManagerStrategy lifetimeChain)
		{
			this._parent = parent;
			this._registrationChain = registrationChain;
			this._registrationMap = registrationMap;
			this._resolverChain = resolverChain;
			this._resolverMap = resolverMap;
			this._lifetimeChain = lifetimeChain;
			this._lifetimeManagerMap = lifetimeManagerMap;
		}

		private PickRegistrationStrategy RegistrationChain {
			get { return this._registrationChain; }
		}

		private FindResolverStrategy ResolverChain {
			get { return this._resolverChain; }
		}

		private FindLifetimeManagerStrategy LifetimeChain {
			get { return this._lifetimeChain; }
		}

		public void AddResolver(IResolver resolver, System.Type toResolve)
		{
			this.AddTypeAgnostingResolver(resolver, toResolve, string.Empty);
		}

		public void AddResolver(IResolver resolver, System.Type toResolve, string identifier)
		{
			this.AddTypeAgnostingResolver(resolver, toResolve, identifier);
		}

		public void AddResolver(System.Type resolver, System.Type toResolve)
		{
			this.AddTypeAgnostingResolver(resolver, toResolve, string.Empty);
		}

		public void AddResolver(System.Type resolver, System.Type toResolve, string identifier)
		{
			this.AddTypeAgnostingResolver(resolver, toResolve, identifier);
		}

		public void AddResolver<TSolution>(IResolver resolver)
		{
			this.AddTypeAgnostingResolver(resolver, typeof(TSolution).UnderlyingSystemType, string.Empty);
		}

		public void AddResolver<TSolution>(IResolver resolver, string identifier)
		{
			this.AddTypeAgnostingResolver(resolver, typeof(TSolution).UnderlyingSystemType, identifier);
		}

		public void AddResolver<TResolver, TSolution>()
		{
			this.AddTypeAgnostingResolver(typeof(TResolver).UnderlyingSystemType, typeof(TSolution).UnderlyingSystemType, string.Empty);
		}

		public void AddResolver<TResolver, TSolution>(string identifier)
		{
			this.AddTypeAgnostingResolver(typeof(TResolver).UnderlyingSystemType, typeof(TSolution).UnderlyingSystemType, identifier);
		}

		private void AddTypeAgnostingResolver(object resolver, Type toResolve, string identifier)
		{
			this._resolverMap.AddOrUpdate(toResolve, identifier, resolver);
		}

		public IIocContainer CreateChildContainer()
		{
			IIocContainer childContainer = new IocContainer(this);
			this._childContainers.Add(childContainer);
			return childContainer;
		}

		public void LinkToLifetime(System.Type type, Type lifetimeManager)
		{
			this.LinkToLifetimeTypeAgnostic(type, string.Empty, lifetimeManager);
		}

		public void LinkToLifetime(System.Type type, Type lifetimeManager, string identifier)
		{
			this.LinkToLifetimeTypeAgnostic(type, identifier, lifetimeManager);
		}

		public void LinkToLifetime(System.Type type, ILifetimeManager lifetimeManager)
		{
			this.LinkToLifetimeTypeAgnostic(type, string.Empty, lifetimeManager);
		}

		public void LinkToLifetime(System.Type type, ILifetimeManager lifetimeManager, string identifier)
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

		public void RegisterType(System.Type original, System.Type implementation)
		{
			this.RegisterTypeAgnostic(original, implementation, string.Empty, new TransientLifetimeManager(), string.Empty);
		}

		public void RegisterType(System.Type original, System.Type implementation, string identifier)
		{
			this.RegisterTypeAgnostic(original, implementation, identifier, new TransientLifetimeManager(), identifier);
		}

		public void RegisterType<T>(System.Type implementation)
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, implementation, string.Empty, new TransientLifetimeManager(), string.Empty);
		}

		public void RegisterType<T>(System.Type implementation, string identifier)
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, implementation, identifier, new TransientLifetimeManager(), identifier);
		}

		public void RegisterType<T>(T instance)
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, instance, string.Empty, new ContainerManagedLifetimeManager(), string.Empty);
		}

		public void RegisterType<T>(T instance, ILifetimeManager lifetimeManager)
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, instance, string.Empty, lifetimeManager, string.Empty);
		}

		public void RegisterType<T>(T instance, string identifier)
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, instance, identifier, new ContainerManagedLifetimeManager(), identifier);
		}

		public void RegisterType<T>(T instance, ILifetimeManager lifetimeManager, string identifier)
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, instance, identifier, lifetimeManager, identifier);
		}

		public void RegisterType<T>(T instance, string registrationIdentifier, ILifetimeManager lifetimeManager, string lifetimeIdentifier)
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, instance, registrationIdentifier, lifetimeManager, lifetimeIdentifier);
		}

		public void RegisterType<T, TImplemented>() where TImplemented : T
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, typeof(TImplemented).UnderlyingSystemType, string.Empty, new TransientLifetimeManager(), string.Empty);
		}

		public void RegisterType<T, TImplemented>(string identifier) where TImplemented : T
		{
			this.RegisterTypeAgnostic(typeof(T).UnderlyingSystemType, typeof(TImplemented).UnderlyingSystemType, identifier, new TransientLifetimeManager(), identifier);
		}

		private void RegisterTypeAgnostic(System.Type original, object implementation, string registrationIdentifier, ILifetimeManager lifetimeManager, string lifetimeIdentifier)
		{
			if (implementation is Type) {
				this._registrationMap.AddOrUpdate(original, registrationIdentifier, (Type)implementation);
			} else {
				this._registrationMap.AddOrUpdate(original, registrationIdentifier, implementation.GetType());
				lifetimeManager.AddInstance(implementation);
				this._resolutions.AddOrUpdate(implementation.GetType(), lifetimeIdentifier, lifetimeManager);
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

		public object Resolve(System.Type type)
		{
			return this.Resolve(type, string.Empty, string.Empty, string.Empty);
		}

		public object Resolve(System.Type type, string identifier)
		{
			return this.Resolve(type, identifier, identifier, identifier);
		}

		private ILifetimeManager GetPreviousResolution(Type type, string lifetimeIdentifier)
		{
			if (this._resolutions.IsInMap(type, lifetimeIdentifier)) {
				return this._resolutions.GetMappedObject(type, lifetimeIdentifier);
			} else if ((this._parent != null)) {
				return this._parent.GetPreviousResolution(type, lifetimeIdentifier);
			}
			return null;
		}

		public object Resolve(System.Type type, string registrationIdentifier, string resolutionIdentifier, string lifetimeIdentifier)
		{
			//Console.Out.WriteLine(String.Format("Resolving {0}", type.FullName))
			if (typeof(IIocContainer).Equals(type)) {
				//Console.Out.WriteLine(String.Format("Resolved {0}", type.FullName))
				return this;
			}
			if (this.GetType().Equals(type)) {
				//Console.Out.WriteLine(String.Format("Resolved {0}", type.FullName))
				return this;
			}

			object instance = null;

			Type mappedType = (Type)this._registrationChain.PickRegistration(type, registrationIdentifier);
			ILifetimeManager lifetimeManager = this.GetPreviousResolution(mappedType, lifetimeIdentifier);
			if ((lifetimeManager != null)) {
				instance = lifetimeManager.GetInstance();
				if ((instance != null)) {
					//Console.Out.WriteLine(String.Format("Resolved {0}", type.FullName))
					return instance;
				}
			}

			IResolver resolver = default(IResolver);
			object unboxedResolver = this._resolverChain.FindResolver(type, resolutionIdentifier);
			if (unboxedResolver is Type) {
				resolver = (IResolver)this.Resolve((Type)unboxedResolver);
			} else {
				resolver = (IResolver)unboxedResolver;
			}

			object unboxedLifetimeManager = this._lifetimeChain.FindLifetimeManager(mappedType, lifetimeIdentifier);
			if (unboxedLifetimeManager is Type) {
				lifetimeManager = (ILifetimeManager)this.Resolve((Type)unboxedLifetimeManager);
			} else {
				lifetimeManager = (ILifetimeManager)unboxedLifetimeManager;
			}

			instance = resolver.ResolveDependency(mappedType, this);
			lifetimeManager.AddInstance(instance);
			this._resolutions.AddOrUpdate(mappedType, lifetimeIdentifier, lifetimeManager);

			//Console.Out.WriteLine(String.Format("Resolved {0}", type.FullName))
			return instance;

		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposedValue) {
				if (disposing) {
					this._resolverMap.Dispose();
					this._lifetimeManagerMap.Dispose();
					this._registrationMap.Dispose();
					this._resolutions.Dispose();
				}
			}
			this._disposedValue = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

	}

}
