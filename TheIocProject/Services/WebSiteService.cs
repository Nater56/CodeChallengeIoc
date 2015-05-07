using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheIocProject.Services
{
	public class WebSiteService : IWebSiteService
	{
		public bool WebIsUp()
		{
			return true;
		}
	}
}