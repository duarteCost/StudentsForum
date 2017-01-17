using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSALConnect.App_GlobalResources;
using MSALConnect.Models;
using MSALConnect.Services;

namespace MSALConnect.Controllers
{
    public class AnswerController : Controller
    {
        private static List<AnswerFile> answerFilesList;
        DB_DIS db = new DB_DIS();
        public ActionResult Index(int Course_id, int id)
        {
            var coursee = db.Courses.Find(Course_id);
            var doubts = db.Doubts.Find(id);
            ViewBag.Course_id = Course_id;
            ViewBag.doubt = doubts;
            ViewBag.answers = doubts.answers;
            ViewBag.answerFiles = answerFilesList;


            return View("Doubts_Answers");
        }



        [HttpPost]
        public ActionResult CreateAnswer(HttpPostedFileBase file, string content, int id, int Course_id, int view)
        {
            var user_id = Session["userNumber"];
            Answer answer = new Answer();
            var question = db.Doubts.Find(id);
            answer.content = content;
            DateTime localDate = DateTime.Now;
            answer.student = db.Students.Find(user_id);
            answer.date = localDate;
            answer.doubts = question;
            db.Answers.Add(answer);
            
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                AnswerFile file1 = new AnswerFile() { name = fileName, filePath = path, answer = answer };
                db.AnswerFiles.Add(file1);
                db.SaveChanges();
                answerFilesList = db.AnswerFiles.ToList();
            }
            db.SaveChanges();
            

           
            if (view == 0)
            {
                return RedirectToAction("Create", "Doubt", new { id = Course_id });
            }
            else
            {
            
                return RedirectToAction("Index", new { Course_id = Course_id , id = id });
            }
            
        }
      


    }
}