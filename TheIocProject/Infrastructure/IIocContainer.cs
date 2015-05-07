using System;
using System.Collections.Generic;
using TheIocProject.Models;

namespace TheIocProject.Infrastructure
{
	public interface IIocContainer
	{
		void Register<TTo, TFrom>(bool isTransient = false);
		TFrom Resolve<TFrom>();
		object Resolve(Type from);
		object ResolveObject(Type from);
		object CreateInstance(RegisteredObject registeredObject);
		IEnumerable<object> GetConstructorParameters(RegisteredObject registeredObject);
	}
}