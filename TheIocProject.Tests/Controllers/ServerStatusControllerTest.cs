using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TheIocProject.Services;

namespace TheIocProject.Tests.Controllers
{
	[TestFixture]
	class ServerStatusControllerTest
	{
		[Test]
		public void ShouldHaveServiceInfoInView()
		{
			
		}

	}
	public class StubServerStatusService : IServerStatusService
	{
		public string GetWorkingServers()
		{
			return "2 and 3";
		}

		public string GetBrokenServers()
		{
			return
		}

		public bool AllServersAreWorking()
		{
			throw new NotImplementedException();
		}
	}

}
