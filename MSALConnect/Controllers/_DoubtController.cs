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
    public abstract class _Doubt : Controller
    {


        public void Create(int id, string content, string question)
        {
            Doubt doubt = new Doubt();
            doubt.content = content;
            doubt.question = question;
            save(doubt, id);
        
        }


        public abstract ActionResult CreateDoubt(int id, string content, string question);

        public abstract void save(Doubt doubt, int id);


        }
}