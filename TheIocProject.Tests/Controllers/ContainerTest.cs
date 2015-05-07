using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TheIocProject.Infrastructure;
using TheIocProject.Services;

namespace TheIocProject.Tests.Controllers
{
	[TestFixture]
	class ContainerTest
	{
		[Test]
		public void ShouldAddToRegistryAndResolve()
		{
			var container = new IocContainer();

			container.Register<IServerStatusService, ServerStatusService>();
			

		}

	}
}
