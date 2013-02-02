using System;

namespace RockSolidIoc
{

	public interface IIocContainer : IDisposable
	{

		IIocContainer CreateChildContainer();

		void AddResolver(Type resolver, Type toResolve);
		void AddResolver(Type resolver, Type toResolve, string identifier);
		void AddResolver(IResolver resolver, Type toResolve);
		void AddResolver(IResolver resolver, Type toResolve, string identifier);
		void AddResolver<TSolution>(IResolver resolver);
		void AddResolver<TSolution>(IResolver resolver, string identifier);
		void AddResolver<TResolver, TSolution>();

		void AddResolver<TResolver, TSolution>(string identifier);
		void LinkToLifetime(Type type, Type lifetimeManager);
		void LinkToLifetime(Type type, Type lifetimeManager, string identifier);
		void LinkToLifetime(Type type, ILifetimeManager lifetimeManager);
		void LinkToLifetime(Type type, ILifetimeManager lifetimeManager, string identifier);
		void LinkToLifetime<T>(ILifetimeManager lifetimeManager);
		void LinkToLifetime<T>(ILifetimeManager lifetimeManager, string identifier);
		void LinkToLifetime<T, TLifetimeManager>() where TLifetimeManager : ILifetimeManager;

		void LinkToLifetime<T, TLifetimeManager>(string identifier) where TLifetimeManager : ILifetimeManager;
		void RegisterType(Type original, Type implementation);
		void RegisterType(Type original, Type implementation, string identifier);
		void RegisterType<T>(Type implementation);
		void RegisterType<T>(Type implementation, string identifier);
		void RegisterType<T>(T instance);
		void RegisterType<T>(T instance, ILifetimeManager lifetimeManager);
		void RegisterType<T>(T instance, string identifier);
		void RegisterType<T>(T instance, ILifetimeManager lifetimeManager, string identifier);
		void RegisterType<T>(T instance, string registrationIdentifier, ILifetimeManager lifetimeManager, string lifetimeIdentifier);
		void RegisterType<T, TImplemented>() where TImplemented : T;
		void RegisterType<T, TImplemented>(string identifier) where TImplemented : T;

		T Resolve<T>();
		T Resolve<T>(string identifier);
		T Resolve<T>(string registrationIdentifier, string resolutionIdentifier, string lifetimeIdentifier);
		object Resolve(Type type);
		object Resolve(Type type, string identifier);
		object Resolve(Type type, string registrationIdentifier, string resolutionIdentifier, string lifetimeIdentifier);

	}

}
