namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Works", new[] { "Course_id" });
            DropIndex("dbo.Works", new[] { "Student_studentNumber" });
            CreateIndex("dbo.Works", "course_id");
            CreateIndex("dbo.Works", "student_studentNumber");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Works", new[] { "student_studentNumber" });
            DropIndex("dbo.Works", new[] { "course_id" });
            CreateIndex("dbo.Works", "Student_studentNumber");
            CreateIndex("dbo.Works", "Course_id");
        }
    }
}
