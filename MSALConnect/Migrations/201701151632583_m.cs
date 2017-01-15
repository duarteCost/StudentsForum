namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Answers", new[] { "Student_studentNumber" });
            DropIndex("dbo.Answers", new[] { "Teacher_teacherID" });
            DropIndex("dbo.Courses", new[] { "Degree_degreeID" });
            DropIndex("dbo.Courses", new[] { "Teacher_teacherID" });
            DropIndex("dbo.Doubts", new[] { "Work_workID" });
            DropIndex("dbo.Doubts", new[] { "Student_studentNumber" });
            RenameColumn(table: "dbo.Answers", name: "Doubt_doubtID", newName: "doubts_doubtID");
            RenameIndex(table: "dbo.Answers", name: "IX_Doubt_doubtID", newName: "IX_doubts_doubtID");
            CreateTable(
                "dbo.AnswerFiles",
                c => new
                    {
                        answerFileID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        filePath = c.String(),
                        answer_answerID = c.Int(),
                    })
                .PrimaryKey(t => t.answerFileID)
                .ForeignKey("dbo.Answers", t => t.answer_answerID)
                .Index(t => t.answer_answerID);
            
            CreateIndex("dbo.Answers", "student_studentNumber");
            CreateIndex("dbo.Answers", "teacher_teacherID");
            CreateIndex("dbo.Doubts", "student_studentNumber");
            CreateIndex("dbo.Doubts", "work_workID");
            CreateIndex("dbo.Courses", "degree_degreeID");
            CreateIndex("dbo.Courses", "teacher_teacherID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerFiles", "answer_answerID", "dbo.Answers");
            DropIndex("dbo.Courses", new[] { "teacher_teacherID" });
            DropIndex("dbo.Courses", new[] { "degree_degreeID" });
            DropIndex("dbo.Doubts", new[] { "work_workID" });
            DropIndex("dbo.Doubts", new[] { "student_studentNumber" });
            DropIndex("dbo.Answers", new[] { "teacher_teacherID" });
            DropIndex("dbo.Answers", new[] { "student_studentNumber" });
            DropIndex("dbo.AnswerFiles", new[] { "answer_answerID" });
            DropTable("dbo.AnswerFiles");
            RenameIndex(table: "dbo.Answers", name: "IX_doubts_doubtID", newName: "IX_Doubt_doubtID");
            RenameColumn(table: "dbo.Answers", name: "doubts_doubtID", newName: "Doubt_doubtID");
            CreateIndex("dbo.Doubts", "Student_studentNumber");
            CreateIndex("dbo.Doubts", "Work_workID");
            CreateIndex("dbo.Courses", "Teacher_teacherID");
            CreateIndex("dbo.Courses", "Degree_degreeID");
            CreateIndex("dbo.Answers", "Teacher_teacherID");
            CreateIndex("dbo.Answers", "Student_studentNumber");
        }
    }
}
