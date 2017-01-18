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
    public abstract class _AnswerController : Controller
    {


        [HttpPost]
        public  void Create(HttpPostedFileBase file, string content, int id, int Course_id)
        {
           
            Answer answer = new Answer();     
            answer.content = content;
            DateTime localDate = DateTime.Now;
            answer.date = localDate;
           
            save(answer, id, file);

        }

    
        public abstract void save(Answer answer, int id, HttpPostedFileBase file);


    }
}