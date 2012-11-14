using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public interface IIocContainer : IDisposable
  {
    IIocContainer CreateChildContainer();

    void AddInstantiator(Type instantiator, Type toCreate);
    void AddInstantiator(Type instantiator, Type toCreate, string identifier);
    void AddInstantiator(IInstantiator instantiator, Type toCreate);
    void AddInstantiator(IInstantiator instantiator, Type toCreate, string identifier);
    void AddInstantiator<TSolution>(IInstantiator instantiator);
    void AddInstantiator<TSolution>(IInstantiator instantiator, string identifier);
    void AddInstantiator<TInstantiator, TSolution>();
    void AddInstantiator<TInstantiator, TSolution>(string identifier);

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
    void RegisterType<T>(T instance, string identifier);
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