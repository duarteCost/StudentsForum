using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Doubt
    {
        public int doubtID { get; set; }
        public string question { get; set; }
        public string content { get; set; }

        public virtual Student student { get; set; }
        public virtual Course course { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
    }
}