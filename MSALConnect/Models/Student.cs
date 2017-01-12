using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Student
    {
        public int studentID { get; set; }
        public string name { get; set; }
        public string email { get; set; }


        
        public virtual ICollection<Work> works { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
        public virtual ICollection<Doubt> doubts { get; set; }
    }
}