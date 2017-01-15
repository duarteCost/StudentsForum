using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Answer
    {
        public int answerID { get; set; }
        public DateTime date { get; set; }
        public string content{ get; set; }

        public virtual Doubt doubts { get; set; }
        public virtual Student student { get; set; }
        public virtual Teacher teacher { get; set; }
    }
}