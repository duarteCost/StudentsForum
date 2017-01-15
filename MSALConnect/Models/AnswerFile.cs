using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class AnswerFile
    {
        public int answerFileID{ get; set; }
        public string name { get; set; }
        public string filePath { get; set; }
        
        public virtual Answer answer { get; set; }
    }
}