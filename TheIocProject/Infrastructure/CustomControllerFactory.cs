using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using TheIocProject.Controllers;
using TheIocProject.Services;

namespace TheIocProject.Infrastructure
{
	public class CustomControllerFactory : IControllerFactory
	{
		private readonly IIocContainer container;
		
		public CustomControllerFactory(IIocContainer container)
		{
			this.container = container; 
		}


/// <summary>
/// Handle the CreateController call for our controllers that we want the container to create
/// </summary>
/// <param name="requestContext"></param>
/// <param name="controllerName"></param>
/// <returns></returns>

		public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
		{
			if (controllerName.ToLower().StartsWith("serverstatus"))
			{

				var controller = container.Resolve<ServerStatusController>();

				return controller; 
			}

			if (controllerName.ToLower().StartsWith("counting"))
			{
				var controller = container.Resolve<CountingController>();

				return controller;
			}

			if (controllerName.ToLower().StartsWith("duel"))
			{
				var controller = container.Resolve<DuelController>();

				return controller;
			}

			
			var defaultFactory = new DefaultControllerFactory();
			return defaultFactory.CreateController(requestContext, controllerName);
		}

		public SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
		{
			return SessionStateBehavior.Default;
		}

		public void ReleaseController(IController controller)
		{
			var disposible = controller as IDisposable;
			if (disposible != null)
			{
				disposible.Dispose();
			}
		}
	}
}