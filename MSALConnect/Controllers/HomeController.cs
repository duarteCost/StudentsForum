/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Graph;
using MSALConnect.App_GlobalResources;
using MSALConnect.Models;
using MSALConnect.Services;

namespace MSALConnect.Controllers
{
    public class HomeController : Controller
    {
        private int i =0;
        [Authorize]
        public async Task<ActionResult> Index()
        {
            ViewBag.Email = await GraphService.Instance.GetMyEmailAddress();
            var studentNumber = ViewBag.Email.Split('@');
            var studentNumberString = studentNumber[0];
            var studentNumberInt = int.Parse(studentNumberString);

            DB_DIS db = new DB_DIS();


            var student = db.Students.Find(studentNumberInt);
            if (student != null)
            {
                var courses = student.degree.courses;
                foreach (var course in courses)
                {
                    i++;
                    Session["courseName" + i] = course.name;
                    Session["courseId" + i] = course.id;
                    Session["Count"] = i;
                }
            }
           
            
            return View("getStudentCorses");
        }

    }
}