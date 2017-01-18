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
    public class DoubtController :  _Doubt 
    {
        

        DB_DIS db = new DB_DIS();

        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.Course_id = id;
            var coursee = db.Courses.Find(id);
            var doubts = coursee.doubts;
            ViewBag.Doubts = doubts;
            
            return View("Course_doubts");
        }




        [HttpPost]
        public override ActionResult CreateDoubt(int id, string content, string question)
        {
            Create(id, content, question);

            return RedirectToAction("Create", "Doubt", new { id = id });
        }


      

        [HttpPost]
        public override void save(Doubt doubt, int id)
        {
            var user_id = Session["userNumber"];
            var coursee = db.Courses.Find(id);
            doubt.course = coursee;
            var user = db.Students.Find(user_id);
            user.doubts.Add(doubt);
            db.SaveChanges();
        

        }

   
    }
}