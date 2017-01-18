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
    public class Projects_DoubtsController :  _Doubt 
    {
       
        DB_DIS db = new DB_DIS();


        public override ActionResult CreateDoubt(int id, string content, string question)
        {
            Create(id, content, question);

            return RedirectToAction("ShowProject", "Projects", new { id = id });
        }


        public override void save(Doubt doubt, int id)
        {
            var Work = db.Works.Find(id);
            Work.doubts.Add(doubt);
            db.SaveChanges();
   
        }



        }
}