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
                var coursee = db.Courses.Find(id);
                doubt.course = coursee;
                db.Doubts.Add(doubt);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(doubt);
        }

        [HttpPost]
        public ActionResult CreateAnswer(string content, int id)
        {
            var question = db.Doubts.Find(id);

            Answer answer = new Answer() ;
            //answer.
            //answer.content = content;
            //DateTime localDate = DateTime.Now;
            //answer.date = localDate;
            //db.Answers.Add(answer);
            //db.SaveChanges();
            //if (ModelState.IsValid)
            //{

            //    db.Answers.Add(answer);
            //    db.SaveChanges();
            //    return RedirectToAction("Create");
            //}

            return View("Course_doubts");
        }
        //public ActionResult AddDoubt(String question, string content)
        //{

        //    DB_DIS db = new DB_DIS();
        //    Doubt doubt = new Doubt();
        //    doubt.content = content;
        //    doubt.question = question;

        //    db.Doubts.Add(doubt);
        //    db.SaveChanges();

        //    return View();

        //}


        //public ActionResult GetDoubts()
        //{
        //    DB_DIS db = new DB_DIS();

        //    Doubt doubt = new Doubt() {question="Teste 1", content = " sadsds" };

        //   // db.Doubts.Add(doubt);
        //    // db.SaveChanges();

        //    ViewBag.Doubts = db.Doubts;

        //    return View("Course_doubts");
        //}


    }
}