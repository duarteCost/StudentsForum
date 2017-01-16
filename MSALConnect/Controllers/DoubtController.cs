using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSALConnect.App_GlobalResources;
using MSALConnect.Models;
using MSALConnect.Services;

namespace MSALConnect.Controllers
{
    public class DoubtController : Controller
    {
        // GET: Doubt
        public ActionResult Index()
        {
            return View();
        }

        DB_DIS db = new DB_DIS();

        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.Course_id = id;
            var coursee = db.Courses.Find(id);

            var doubtssss = coursee.doubts;
            var doubts = db.Doubts.FindAsync(coursee);


            ViewBag.Doubts = doubtssss;

            return View("Course_doubts");
        }

        [HttpPost]
        public ActionResult Create(Doubt doubt, int id)
        {
            if (ModelState.IsValid)
            {
                var user_id = Session["userNumber"];
                var coursee = db.Courses.Find(id);
                doubt.course = coursee;
                var user = db.Students.Find(user_id);
                user.doubts.Add(doubt);
                
               // db.Doubts.Add(doubt);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(doubt);
        }


     
        public ActionResult CreateDoubt(int Work_id, string content, string question)
        {

            Doubt doubt = new Doubt();

            var Work = db.Works.Find(Work_id);
            doubt.content = content;
            doubt.question = question;
            Work.doubts.Add(doubt);
            db.SaveChanges();

            return RedirectToAction("ShowProject", "Projects", new { id = Work_id });
        }





    }
}