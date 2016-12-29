using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Graph;
using MSALConnect.App_GlobalResources;
using MSALConnect.Models;
using MSALConnect.Services;


namespace MSALConnect.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCourses(int id)
        {
            DB_DIS db = new DB_DIS();

            var degree = db.Degrees.Find(id);
            if (degree != null)
            {
                ViewBag.Courses = degree.courses;
            }

            return View();
        }

        public ActionResult Course_Page(int id)
        {
            ViewBag.id_course = id;
            return View();
        }

        public ActionResult Course_doubt(int id)
        {
            return View();
        }

        public ActionResult Course_Projects(int id)
        {
            return View();
        }


    }
}