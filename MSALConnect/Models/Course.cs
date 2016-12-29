using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MSALConnect.Models
{
    public class Course
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
        public int semester { get; set; }
        public int year { get; set; }
        
        public virtual ICollection<Doubt> doubts { get; set; }
        public virtual ICollection<Work> works { get; set; }
    }
}