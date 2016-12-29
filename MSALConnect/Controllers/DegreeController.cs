using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Graph;
using MSALConnect.App_GlobalResources;
using MSALConnect.Models;
using MSALConnect.Services;

namespace MSALConnect.Controllers
{
    public class DegreeController : Controller
    {
        // GET: Degree
        public ActionResult Index()
        {
            return View();
        }

        //------------------------------------------------------------------------------//
        //[Authorize]
        //// Get the current user's email address from their profile.
        public ActionResult GetDegrees()
        {
            DB_DIS db = new DB_DIS();


            ViewBag.Degrees = db.Degrees;
            return View();
        }


        

        //------------------------------------------------------------------------------//
    }
}