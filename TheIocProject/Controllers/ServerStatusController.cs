using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheIocProject.Services;

namespace TheIocProject.Controllers
{
    public class ServerStatusController : Controller
    {
	    private IServerStatusService service;

	    public ServerStatusController (IServerStatusService service)
	    {
		    this.service = service;
	    }
        // GET: ServerStatus
        public ActionResult Index()
        {

	        ViewBag.Up = service.GetWorkingServers();
	        ViewBag.Down = service.GetBrokenServers();
	        ViewBag.NoWorries = service.AllServersAreWorking();
            return View();
        }
    }
}