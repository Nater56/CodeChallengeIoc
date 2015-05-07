using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheIocProject.Services;

namespace TheIocProject.Controllers
{
    public class CountingController : Controller
    {
	    private readonly ICountingService count;

	    public CountingController(ICountingService count)
	    {
		    this.count = count;
	    }
        // GET: Counting
        public ActionResult Index()
        {
	        ViewBag.Number = count.GetNumber();
            return View();
        }
    }
}