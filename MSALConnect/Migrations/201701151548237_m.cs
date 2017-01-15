namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Doubts", new[] { "Student_studentNumber" });
            CreateTable(
                "dbo.AnswerFiles",
                c => new
                    {
                        answerFileID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        filePath = c.String(),
                    })
                .PrimaryKey(t => t.answerFileID);
            
            AddColumn("dbo.Answers", "answerFile_answerFileID", c => c.Int());
            CreateIndex("dbo.Answers", "answerFile_answerFileID");
            CreateIndex("dbo.Doubts", "student_studentNumber");
            AddForeignKey("dbo.Answers", "answerFile_answerFileID", "dbo.AnswerFiles", "answerFileID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "answerFile_answerFileID", "dbo.AnswerFiles");
            DropIndex("dbo.Doubts", new[] { "student_studentNumber" });
            DropIndex("dbo.Answers", new[] { "answerFile_answerFileID" });
            DropColumn("dbo.Answers", "answerFile_answerFileID");
            DropTable("dbo.AnswerFiles");
            CreateIndex("dbo.Doubts", "Student_studentNumber");
        }
    }
}
