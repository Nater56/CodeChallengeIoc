using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TheIocProject.Exceptions;
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
			//arange
			var container = new IocContainer();
			//act
			container.Register<IServerStatusService, ServerStatusService>();
			var result = container.Resolve<IServerStatusService>();
			//assert
			Assert.IsInstanceOf<ServerStatusService>(result);

		}
		[Test]
		public void ShouldAddToRegistryAndResolveAsSingleton()
		{
			//arange
			var container = new IocContainer();
			//act
			container.Register<ICountingService, CountingService>(false);
			var result = container.Resolve<ICountingService>();
			//assert
			Assert.AreEqual(0, result.GetNumber());
			Assert.IsInstanceOf<CountingService>(result);
			Assert.IsInstanceOf<CountingService>(result);
			Assert.AreEqual(1, result.GetNumber());
		}

		[Test]
		public void ShouldThrowNotRegisteredException()
		{	
			//arrange
			var container = new IocContainer();
			//act
			//assert
			Assert.Throws<NotRegisteredException>(() => container.Resolve<CountingService>());
		}
	}
}
