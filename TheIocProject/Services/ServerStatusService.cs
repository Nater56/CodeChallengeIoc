using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TheIocProject.Services
{
	public class ServerStatusService : IServerStatusService
	{
		public string GetWorkingServers()
		{
			return "There are currently 5 working servers.";
		}

		public string GetBrokenServers()
		{
			return "There are currently 2 broken servers.";
		}

		public bool AllServersAreWorking()
		{
			return false; 
		}
	}
}