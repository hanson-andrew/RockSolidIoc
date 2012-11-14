RockSolidIoC
============

Inspired by [Unity](http://unity.codeplex.com/), this is a simple and flexible IOC container for .NET.

Getting Started
---------------
**Simple Dependencies**

    public class NeedyObject {
      private FirstDependency _firstNeed;
      public NeedyObject(FirstDependency firstNeed) {
        this._firstNeed = firstNeed;
      }
    }

The `NeedyObject` has declared a dependency on the class `FirstDependency` by requiring it in it's constructor. We can instantiate this object by calling:

    rockSolidIocInstance.Resolve<NeedyObject>();

The container creates an instance of `FirstDependency` because it needs to use it in the constructor, the it invokes the constructor and returns the requested `NeedyObject`.

**Interface Dependencies - Single Implementation**

    public class NeedyObject {
      private IFirstDependency _firstNeed;
      public NeedyObject(IFirstDependency firstNeed) {
        this._firstNeed = firstNeed;
      }
    }

    rockSolidIocInstance.Resolve<NeedyObject>();

Behind the scenes, there's only one implementation of `IFirstDependency`. Because there's only one, the container assumes you want that one. It creates it, uses it in the constructor, and returns `NeedyObject`. 

**Interface Dependencies - Multiple Implementations**

    public class NeedyObject {
      private ISuperInterface _firstNeed;
      public NeedyObject(ISuperInterface firstNeed) {
        this._firstNeed = firstNeed;
      }
    }

    rockSolidIocInstance.Resolve<NeedyObject>();

In this scenario `ISuperInterface` has multiple implementations. We can do a couple of things to make this work. First we can map the type in our app.config or web.config file

    <RockSolidIoc>
      <type-mappings>
        <type-mapping type="FakeNamespace.ISuperInterface" mapTo="FakeNamespace.DefaultSuperInterfaceImplementation" />
      </type-mappings>
    </RockSolidIoc>

We can register this through the API before calling `Resolve`:

    rockSolidIocInstance.Register<ISuperInterface, DefaultSuperInterfaceImplemntation>();

Lastly, we can mark ISuperInterface with the type it should be mapped to:

    [MapTo(typeof(DefaultSuperInterfaceImplementation))]
    public interface ISuperInterface { }

**Complex Interface Dependencies**

    public class NeedyObject {
      private ISuperInterface _firstNeed;
      private ISuperInterface _secondNeed;
      public NeedyObject(ISuperInterface firstNeed, ISuperInterface secondNeed) {
        this._firstNeed = firstNeed;
        this._secondNeed = secondNeed;
      }
    }

Assuming you want different implementations of `ISuperInterface` for `firstNeed` and `secondNeed`, this class needs to be altered. Because we haven't put any clarifying identifiers on this dependency declarations, both will get the default. If we want something different than the default, we need to be explicit about that.

    public class NeedyObject {
      private ISuperInterface _firstNeed;
      private ISuperInterface _secondNeed;
      public NeedyObject(ISuperInterface firstNeed, [IocDependency("Specific")] ISuperInterface secondNeed) {
        this._firstNeed = firstNeed;
        this._secondNeed = secondNeed;
      }
    }

To accomplish this, we would need to change our above mappings.

XML:

    <RockSolidIoc>
      <type-mappings>
        <type-mapping type="FakeNamespace.ISuperInterface" mapTo="FakeNamespace.DefaultSuperInterfaceImplementation" />
        <type-mapping type=FakeNamespace.ISuperInterface" mapTo="FakeNamespace.SpecificSuperInterfaceImplement" identifier="Specific" />
      </type-mappings>
    </RockSolidIoc>

API:

    rockSolidIocContainer.Register<ISuperInterface, DefaultSuperInterfaceImplementation>();
    rockSolidIocContainer.Register<ISuperInterface,SpecificSuperInterfaceImplementation>("Specific");

Attribute:

    [MapTo(typeof(DefaultSuperInterfaceImplementation))]
    [MapTo(typeof(SpecificSuperInterfaceImplementation),"Specific")]
    public interface ISuperInterface { }


Instantiating Dependencies
--------------------------
RockSolidIoc comes with a simple object instantiator that is capable of creating most simple objects. To create the object, it picks the constructor with the most parameters to satisfy (just like Unity). It then uses the container to satisfy each of those parameters and invokes the constructor to create the object. It then scans the object for any properties that are marked with a `IocDependency` attribute, and attempts to set that property using the container to find an object for the property. It then scans for methods marked with the same attribute. Any parameters to one of those methods would be created through the container, and then the method would be invoked.

Occasionally, you need to override this instantiation behavior. The most common scenario is that you need to inject something into the object that you won't know until runtime. These instantiators are registered to the object that's being created. You won't ever register an instantiator to an interface, because you won't be creating the interface.

XML:

    <RockSolidIoc>
      <instantiators>
        <instantiator type="FakeNamespace.SpecificSuperInterfaceImplementation" instantiator-type="FakeNamespace.RuntimeSpecificImplementationInstantiator" />
      </instantiators>
    </RockSolidIoc>

API:

    rockSolidIocContainer.AddInstantiator<RuntimeSpecificImplementationInstantiator>();


Attributes:

    [UseInstantiator(typeof(RuntimeSpecificImplementationInstantiator))]
    public class SpecificSuperInterfaceImplementation { }

Lifetime Management
-------------------
By default, all objects created by the IOC container use the `TransientLifetimeManager` which means they are recreated each time they are needed. To change this, you need to register the concrete type with the appropriate lifetime manager.

XML:

    <RockSolidIoc>
      <lifetime-manager-mappings>
        <lifetime-manager-mapping type="FakeNamespace.SpecificSuperInterfaceImplementation" lifetime-manager-type="RockSolidIoc.ContainerManagedLifetimeManager" />
      </lifetime-manager-mappings>
    </RockSolidIoc>

API:

    rockSolidIocContainer.LinkToLifetime<SpecificSuperInterfaceImplementation, ContainerManagedLifetimeManager>();

Attributes:

    [UseLifetimeManager(typeof(ContainerManagedLifetimeManager))]
    public class SpecificSuperInterfaceImplementation

Attaching the lifetime manager to the instantiated type means you have the ability of mapping multiple interfaces to the same object, and have that object all managed by the same lifetime manager. 

RockSolidIoc comes with the following lifetime managers:

* ContainerManagedLifetimeManager
* ExternallyControlledLifetimeManager
* TransientLifetimeManger

You can implement your own lifetime managers by implementing the `ILifetimeManager` interface.

Going Forward
-------------

There's a lot of work left to do on the container. I need a lot more documentation, both in code and guides to get people started using the container. Some more work could be done on the tests to get them covering everything. I'm sure there's opportunities within the code to improve it on a whole as well. 