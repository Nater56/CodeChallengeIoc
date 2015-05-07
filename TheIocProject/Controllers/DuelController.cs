using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheIocProject.Services;

namespace TheIocProject.Controllers
{
    public class DuelController : Controller
    {
	    private readonly IWebSiteService site;
	    private readonly IServerStatusService server;

		public DuelController(IWebSiteService site, IServerStatusService server)
		{
			this.site = site;
			this.server = server;
		}
        // GET: Duel
        public ActionResult Index()
        {
	        ViewBag.Server = server.AllServersAreWorking();
	        ViewBag.Site = site.WebIsUp();
            return View();
        }
    }
}