using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSALConnect.Models;

namespace MSALConnect.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowNotification()
        {
            DB_DIS db = new DB_DIS();
            //db.Notifications
            return View();
        }
        
    }
}