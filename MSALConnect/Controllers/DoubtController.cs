using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSALConnect.Controllers
{
    public class DoubtController : Controller
    {
        // GET: Doubt
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Course_doubt(int id)
        {
            return View();
        }
    }
}