using System.Collections.Generic;

namespace MSALConnect.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DB_DIS : DbContext
    {
        public DB_DIS()
            : base("name=DB_DIS")
        {
        }
        
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Doubt> Doubts { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<AnswerFile> AnswerFiles { get; set; }
    }
}