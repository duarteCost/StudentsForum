using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSALConnect.Models
{
    public class StudentsClassification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Key]
        public virtual Student studentId { get; set; }
        public virtual Classification classificationId { get; set; }
    }
}