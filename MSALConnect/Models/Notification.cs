using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Notification
    {
        public int notificationID { get; set; }
        public string content { get; set; }

        public virtual Student student { get; set; }
    }
}