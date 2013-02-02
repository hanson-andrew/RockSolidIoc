using System;
using System.Reflection;

namespace RockSolidIoc
{

	internal class Resolver : IResolver
	{

		public object ResolveDependency(Type type, IIocContainer context)
		{
			ConstructorInfo injectionConstructor = this.GetInjectionConstructor(type);

			object[] dependentObjects = this.ResolveParameters(injectionConstructor, context);

			//Invoke the constructor with the resolved objects and return the result
			object obj = injectionConstructor.Invoke(dependentObjects);

			PropertyInfo[] propertyList = type.GetProperties();
			foreach (PropertyInfo prop in propertyList) {
				Attribute[] attributes = (Attribute[]) prop.GetCustomAttributes(typeof(IocDependencyAttribute), true);
				if (attributes.Length > 0) {
					IocDependencyAttribute dependencyAttribute = (IocDependencyAttribute)attributes[0];
					object propValue = context.Resolve(prop.PropertyType, dependencyAttribute.Identifier);
					prop.SetValue(obj, propValue, null);
				}
			}

			MethodInfo[] methodList = type.GetMethods();
			foreach (MethodInfo method in methodList) {
				Attribute[] attributes = (Attribute[]) method.GetCustomAttributes(typeof(IocDependencyAttribute), true);
				if (attributes.Length > 0) {
					object[] methodParameters = this.ResolveParameters(method, context);
					method.Invoke(obj, methodParameters);
				}
			}
			return obj;
		}

		private ConstructorInfo GetInjectionConstructor(Type type)
		{
			ConstructorInfo[] constructors = type.GetConstructors();
			ConstructorInfo injectionConstructor = null;
			bool attributedFound = false;
			bool maxLengthFound = false;
			int maxParamCount = -1;
			foreach (ConstructorInfo constructor in constructors) {
				if (constructor.GetCustomAttributes(typeof(IocConstructorAttribute), false).Length > 0) {
					if (attributedFound) {
						throw new IocException("Multiple constructors marked as injection points on type " + type.UnderlyingSystemType.ToString());
					} else {
						attributedFound = true;
						injectionConstructor = constructor;
					}
				} else {
					int paramLength = constructor.GetParameters().Length;
					if (!attributedFound && paramLength > maxParamCount) {
						maxLengthFound = true;
						maxParamCount = paramLength;
						injectionConstructor = constructor;
					} else if (!attributedFound && paramLength == maxParamCount && maxLengthFound) {
						throw new IocException("Multiple constructors with maximum parameter count on type " + type.UnderlyingSystemType.ToString());
					}
				}
			}
			if ((injectionConstructor == null)) {
				throw new IocException("Could not resolve constructor for: " + type.UnderlyingSystemType.ToString());
			}
			return injectionConstructor;
		}

		private object[] ResolveParameters(MethodBase methodBase, IIocContainer context)
		{
			//Gets a list of parameters to attempt to resolve those parameters 
			//before calling the constructor with the resolved objects
			ParameterInfo[] methodParams = methodBase.GetParameters();
			object[] dependentObjects = new object[methodParams.Length];
			int paramIndexer = 0;
			for (paramIndexer = 0; paramIndexer <= methodParams.Length - 1; paramIndexer++) {
				ParameterInfo param = (ParameterInfo) methodParams.GetValue(paramIndexer);

				try {
					string identString = string.Empty;
					Attribute[] attrs = (Attribute[])param.GetCustomAttributes(typeof(IocDependencyAttribute), false);
					//Parameters can be specified with an IocDependencyAttribute if a specific string must be used
					if (attrs.Length > 0) {
						IocDependencyAttribute dependentAttr = (IocDependencyAttribute) attrs.GetValue(0);
						identString = dependentAttr.Identifier;
					}
					object paramValue = context.Resolve(param.ParameterType, identString);
					dependentObjects.SetValue(paramValue, paramIndexer);
				} catch (IocException) {
					throw new IocException("Could not resolve parameter type: " + param.ParameterType.UnderlyingSystemType.ToString());
				}
			}
			return dependentObjects;
		}

	}

}
