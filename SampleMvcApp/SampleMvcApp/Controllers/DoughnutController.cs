using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class DoughnutController : Controller
    {
        // GET: Doughnut
        public ActionResult Index()
        {
            return View();
        }
    }
}