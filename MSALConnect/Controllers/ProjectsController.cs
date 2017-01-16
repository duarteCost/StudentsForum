using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSALConnect.Models;

namespace MSALConnect.Controllers
{
    public class ProjectsController : Controller
    {
        private static int courseID;
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult uploadFile(HttpPostedFileBase file, string nameWork)
        {
            DB_DIS db = new DB_DIS();
            var b = Session["userNumber"];
            Course course = db.Courses.Find(courseID);

            Student student = db.Students.Find(b);
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                // adicionar na base de dados
                Work work = new Work() { name = fileName, nameWork = nameWork, filePath = path, course = course, student = student };
                db.Works.Add(work);
                db.SaveChanges();
            }

            

            var w = course.works;
            ViewBag.Projetos = w;
            return View("Course_Projects");
        }

        public ActionResult ShowProject(int id)
        {
            DB_DIS db = new DB_DIS();
            Work work = db.Works.Find(id);
            ViewBag.work = work;

            // JORGE //
            ViewBag.Doubts = work.doubts;
            


            // FIM JORGE //
            return View();
        }

        public FileResult Download(string pathName, string fileName)
        {
            string Arquivo = fileName;
            FileStream stream = new FileStream(pathName, FileMode.Open);
            return File(stream, "download", Arquivo);
        }
        //------------------------//

        public ActionResult Course_Projects(int id)
        {
            courseID = id;
            DB_DIS db = new DB_DIS();

            var course = db.Courses.Find(id);
            Session["getCoursesId"] = course.id;
            if (course != null)
            {
                ViewBag.Projetos = course.works;
                Session["CorseNameInProjects"] = course.name;
            }
            return View();
        }
    }

}