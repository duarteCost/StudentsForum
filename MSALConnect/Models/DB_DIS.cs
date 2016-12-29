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
    }

    //public class Degrees
    //{
    //    public int degreeID { get; set; }
    //    public string name { get; set; }

    //    public virtual ICollection<Course> courses { get; set; }
    //}

    //public class Courses
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public int semester { get; set; }
    //    public int year { get; set; }

    //    public virtual ICollection<Doubt> doubts { get; set; }
    //}
    //public class Doubts
    //{
    //    public int doubt_Id { get; set; }
    //    public string question { get; set; }
    //    public string content { get; set; }

    //    public virtual ICollection<Answer> answers { get; set; }
    //}
    //public class Works
    //{
    //    public int workID { get; set; }
    //    public string name { get; set; }
    //    public string filePath { get; set; }

    //    public virtual ICollection<Doubt> doubts { get; set; }
    //}
    //public class Answers
    //{
    //    public int answerID { get; set; }
    //    public DateTime date { get; set; }
    //    public string content { get; set; }
    //}
    //public class Teachers
    //{
    //    public int teacherID { get; set; }
    //    public string name { get; set; }
    //    public string email { get; set; }

    //    public virtual ICollection<Course> courses { get; set; }
    //    public virtual ICollection<Answer> answers { get; set; }
    //}
    //public class Students
    //{
    //    public int studentID { get; set; }
    //    public string name { get; set; }
    //    public string email { get; set; }

    //    public virtual ICollection<Work> works { get; set; }
    //    public virtual ICollection<Answer> answers { get; set; }
    //    public virtual ICollection<Doubt> doubts { get; set; }
    //}
}