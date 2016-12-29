using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Degree
    {
        public int degreeID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Course> courses { get; set; }
        public virtual ICollection<Student> students { get; set; }
    }
}