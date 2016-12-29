using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Teacher
    {
        public int teacherID { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public virtual ICollection<Course> courses { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
    }
}