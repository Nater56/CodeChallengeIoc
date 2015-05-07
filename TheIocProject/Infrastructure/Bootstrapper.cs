using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheIocProject.Controllers;
using TheIocProject.Services;

namespace TheIocProject.Infrastructure
{
	public class BootStrapper
	{
		public static void Configure(IIocContainer container)
		{
			container.Register<CountingController, CountingController>(false);
			container.Register<ICountingService, CountingService>(false);
			container.Register<ServerStatusController, ServerStatusController>();
			container.Register<IServerStatusService, ServerStatusService>();
			container.Register<IWebSiteService, WebSiteService>();
			container.Register<DuelController, DuelController>();
		}
	}
}