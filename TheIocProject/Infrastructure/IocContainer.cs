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
		/// <summary>
		/// Create our object registry
		/// </summary>
		private readonly IList<RegisteredObject> _objectRegistry = new List<RegisteredObject>();
		/// <summary>
		/// Handle the registration of objects
		/// </summary>
		/// <typeparam name="TFrom"></typeparam>
		/// <typeparam name="TTo"></typeparam>
		/// <param name="isTransient"></param>
		public void Register<TFrom, TTo>(bool isTransient = true)
		{
			_objectRegistry.Add(new RegisteredObject(typeof(TFrom), typeof(TTo), isTransient));
		}
		/// <summary>
		/// Take passed in object and call the ResolveObject method to return the instance
		/// </summary>
		/// <typeparam name="TFrom"></typeparam>
		/// <returns></returns>
		 public TFrom Resolve<TFrom>()
        {
            return (TFrom) ResolveObject(typeof (TFrom));
        }
		/// <summary>
		/// Overload take passed in object parameter and call the ResolveObject method to return the instance
		/// </summary>
		/// <param name="from"></param>
		/// <returns></returns>
        public object Resolve(Type from)
        {
            return ResolveObject(from);
        }

		/// <summary>
		/// Find our object in the registry or throw an exception if it is not found. If found we can call CreateInstance
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
		/// <summary>
		/// Resolve the object either by returning the existing object if !Transient or by returning the CreateInstance method
		/// </summary>
		/// <param name="registeredObject"></param>
		/// <returns></returns>

		public object CreateInstance(RegisteredObject registeredObject)
        {
	        if (registeredObject.Instance != null && !registeredObject.IsTransient) 
				return registeredObject.Instance;
	        var parameters = GetConstructorParameters(registeredObject);
	        registeredObject.CreateInstance(parameters.ToArray());
	        return registeredObject.Instance;
        }

		/// <summary>
		/// I get the construction arguments for the passed in object and return them
		/// </summary>
		/// <param name="registeredObject"></param>
		/// <returns></returns>
		public IEnumerable<object> GetConstructorParameters(RegisteredObject registeredObject)
        {
	        var constructorInfo = registeredObject.To.GetConstructors().First();
	        return constructorInfo.GetParameters().Select(p => ResolveObject(p.ParameterType));
        }
	}
}

