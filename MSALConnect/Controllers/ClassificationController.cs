using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSALConnect.Models;

namespace MSALConnect.Controllers
{
    public class ClassificationController : Controller
    {
        // GET: Classification
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult classify(int rate, int id)
        {
            ViewBag.result = rate;
            DB_DIS db = new DB_DIS();
            Work work = db.Works.Find(id);
            if (work.classication.classificationId == null)
            {
                //Classification classification = new Classification() { classificationNamber = fileName, filePath = path, ce = course, student = student };
                //db.Answers.Add(answer);
                //db.SaveChanges();
            }
            return View("");
        }   
}
}