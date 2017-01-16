using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentID { get; set; }
        [Key]
        public int studentNumber { get; set; }
        public string name { get; set; }
        public string email { get; set; }


        public virtual Degree degree { get; set; }
        public virtual ICollection<Classification> classifications { get; set; }
        public virtual ICollection<Work> works { get; set; }
        public virtual ICollection<Notification> notifications { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
        public virtual ICollection<Doubt> doubts { get; set; }
    }
}