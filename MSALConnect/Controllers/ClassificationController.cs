﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.Identity.Client;
using MSALConnect.Migrations;
using MSALConnect.Models;

namespace MSALConnect.Controllers
{
    public class ClassificationController : Controller
    {
        private int rate;
        // GET: Classification
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult classify(int rate, int id)
        {
            this.rate = rate;

            DB_DIS db = new DB_DIS();
            var studentNumber = Session["userNumber"];
            Student student = db.Students.Find(studentNumber);
            ViewBag.result = rate;
            Work work = db.Works.Find(id);
            

            if (student.classifications.Contains(work.classification))
            {
                ViewBag.alert = "Apenas pode avialiar uma vez";
            }
            else
            {
                if (null == work.classification)
                {
                    Classification classification = CreateClassification();
                    work.classification = classification;
                    student.classifications.Add(classification);
                    db.SaveChanges();
                }
                else
                {
                    var classificationValue = work.classification.classificationValue;
                    var classificationNumber = work.classification.classificationNamber;
                    work.classification.classificationValue = (classificationNumber * classificationValue + rate) /
                                                              (classificationNumber + 1);
                    work.classification.classificationNamber = classificationNumber + 1;
                    student.classifications.Add(work.classification);
                    db.SaveChanges();
                }
                
            }

            
            ViewBag.work = work;
            return View("~/Views/Projects/ShowProject.cshtml");
        }

        public Classification CreateClassification()
        {
            DB_DIS db = new DB_DIS();
            Classification classification = new Classification()
            {
                classificationNamber = 1,
                classificationValue = rate
            };
            db.Classifications.Add(classification);
            db.SaveChanges();
            return classification;
        }
    }
}