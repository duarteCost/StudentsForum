using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Work
    {
        public int workID { get; set; }
        public string name { get; set; }
        public string nameWork { get; set; }
        public string filePath { get; set; }

        public virtual Student student { get; set; }
        public virtual Course course { get; set; }
        public virtual Classification classification { get; set; }
        public virtual ICollection<Doubt> doubts { get; set; }
    }
}