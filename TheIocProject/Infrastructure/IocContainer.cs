using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;
using TheIocProject.Exceptions;
using TheIocProject.Models;

namespace TheIocProject.Infrastructure
{
	public class IocContainer : IIocContainer
	{
		private readonly IList<RegisteredObject> _objectRegistry = new List<RegisteredObject>();
		public void Register<TFrom, TTo>(bool isTransient = true)
		{
			_objectRegistry.Add(new RegisteredObject(typeof(TFrom), typeof(TTo), isTransient));
		}

		 public TFrom Resolve<TFrom>()
        {
            return (TFrom) ResolveObject(typeof (TFrom));
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <returns></returns>
        public object Resolve(Type from)
        {
            return ResolveObject(from);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="from"></param>
		/// <returns></returns>
		public object ResolveObject(Type from)
        {
            var registeredObject = _objectRegistry.FirstOrDefault(p => p.From == from);
            if (registeredObject == null)
            {
	            throw new NotRegisteredException(from.Name + " Has not been registered to this container.");
            }
            return CreateInstance(registeredObject);
        }

		public object CreateInstance(RegisteredObject registeredObject)
        {
	        if (registeredObject.Instance != null && !registeredObject.IsTransient) 
				return registeredObject.Instance;
	        var parameters = GetConstructorParameters(registeredObject);
	        registeredObject.CreateInstance(parameters.ToArray());
	        return registeredObject.Instance;
        }

		public IEnumerable<object> GetConstructorParameters(RegisteredObject registeredObject)
        {
	        var constructorInfo = registeredObject.To.GetConstructors().First();
	        return constructorInfo.GetParameters().Select(p => ResolveObject(p.ParameterType));
        }
	}
}

