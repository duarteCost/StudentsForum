namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class D : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        answerID = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        content = c.String(),
                        Doubt_doubtID = c.Int(),
                        Student_studentID = c.Int(),
                        Teacher_teacherID = c.Int(),
                    })
                .PrimaryKey(t => t.answerID)
                .ForeignKey("dbo.Doubts", t => t.Doubt_doubtID)
                .ForeignKey("dbo.Students", t => t.Student_studentID)
                .ForeignKey("dbo.Teachers", t => t.Teacher_teacherID)
                .Index(t => t.Doubt_doubtID)
                .Index(t => t.Student_studentID)
                .Index(t => t.Teacher_teacherID);
            
            CreateTable(
                "dbo.Doubts",
                c => new
                    {
                        doubtID = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        content = c.String(),
                        Course_id = c.Int(),
                        Student_studentID = c.Int(),
                        Work_workID = c.Int(),
                    })
                .PrimaryKey(t => t.doubtID)
                .ForeignKey("dbo.Courses", t => t.Course_id)
                .ForeignKey("dbo.Students", t => t.Student_studentID)
                .ForeignKey("dbo.Works", t => t.Work_workID)
                .Index(t => t.Course_id)
                .Index(t => t.Student_studentID)
                .Index(t => t.Work_workID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.studentID);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        workID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        filePath = c.String(),
                        Student_studentID = c.Int(),
                    })
                .PrimaryKey(t => t.workID)
                .ForeignKey("dbo.Students", t => t.Student_studentID)
                .Index(t => t.Student_studentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        teacherID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.teacherID);
            
            AddColumn("dbo.Courses", "semester", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "year", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Teacher_teacherID", c => c.Int());
            CreateIndex("dbo.Courses", "Teacher_teacherID");
            AddForeignKey("dbo.Courses", "Teacher_teacherID", "dbo.Teachers", "teacherID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Teacher_teacherID", "dbo.Teachers");
            DropForeignKey("dbo.Answers", "Teacher_teacherID", "dbo.Teachers");
            DropForeignKey("dbo.Works", "Student_studentID", "dbo.Students");
            DropForeignKey("dbo.Doubts", "Work_workID", "dbo.Works");
            DropForeignKey("dbo.Doubts", "Student_studentID", "dbo.Students");
            DropForeignKey("dbo.Answers", "Student_studentID", "dbo.Students");
            DropForeignKey("dbo.Doubts", "Course_id", "dbo.Courses");
            DropForeignKey("dbo.Answers", "Doubt_doubtID", "dbo.Doubts");
            DropIndex("dbo.Works", new[] { "Student_studentID" });
            DropIndex("dbo.Doubts", new[] { "Work_workID" });
            DropIndex("dbo.Doubts", new[] { "Student_studentID" });
            DropIndex("dbo.Doubts", new[] { "Course_id" });
            DropIndex("dbo.Courses", new[] { "Teacher_teacherID" });
            DropIndex("dbo.Answers", new[] { "Teacher_teacherID" });
            DropIndex("dbo.Answers", new[] { "Student_studentID" });
            DropIndex("dbo.Answers", new[] { "Doubt_doubtID" });
            DropColumn("dbo.Courses", "Teacher_teacherID");
            DropColumn("dbo.Courses", "year");
            DropColumn("dbo.Courses", "semester");
            DropTable("dbo.Teachers");
            DropTable("dbo.Works");
            DropTable("dbo.Students");
            DropTable("dbo.Doubts");
            DropTable("dbo.Answers");
        }
    }
}
