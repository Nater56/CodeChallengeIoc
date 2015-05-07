using System;
using System.Collections.Generic;

namespace TheIocProject.Container
{
	public interface IIocContainer
	{
		void Register<TTo, TFrom>();
		void Register<TTo, TFrom>(bool isTransient);
		TFrom Resolve<TFrom>();
		object Resolve(Type from);
		object ResolveObject(Type from);
		object CreateInstance(RegisteredObject registeredObject);
		IEnumerable<object> GetConstructorParameters(RegisteredObject registeredObject);
	}
}