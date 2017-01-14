using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MSALConnect.Models;
using MSALConnect.Services;

namespace MSALConnect.Controllers
{
    public class DoubtController : Controller
    {
        // GET: Doubt
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Course_doubts(int id)
        {
            DB_DIS db = new DB_DIS();


            var course = db.Courses.Find(id);
            if (course != null)
            {
                ViewBag.course = course;
            }
            return View();
        }
    }
}