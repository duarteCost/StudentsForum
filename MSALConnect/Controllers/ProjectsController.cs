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
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult uploadFile(HttpPostedFileBase file)
        {

            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            string[] arquivos = Directory.GetFiles(Server.MapPath("~/App_Data/uploads"));
            ViewBag.Projetos = arquivos;
            // redirect back to the index action to show the form once again
            return View("Course_Projects");
        }

        public ActionResult ShowProject(string pathName)
        {
            ViewBag.PathName = pathName;
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
            string[] arquivos = Directory.GetFiles(Server.MapPath("~/App_Data/uploads"));
            ViewBag.Projetos = arquivos;
            DB_DIS db = new DB_DIS();


            var course = db.Courses.Find(id);
            if (course != null)
            {
                Session["CorseNameInProjects"] = course.name;
            }
            return View();
        }
    }

}