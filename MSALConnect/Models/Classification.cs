using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class Classification
    {
        public int classificationId { get; set; }
        public double classificationNamber { get; set; }
        public double classificationValue { get; set; }

        public virtual ICollection<Work> works { get; set; }
        public virtual ICollection<Doubt> doubts { get; set; }
    }
}