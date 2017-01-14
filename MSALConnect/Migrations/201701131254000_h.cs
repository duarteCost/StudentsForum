namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Student_studentID", "dbo.Students");
            DropForeignKey("dbo.Doubts", "Student_studentID", "dbo.Students");
            DropForeignKey("dbo.Works", "Student_studentID", "dbo.Students");
            RenameColumn(table: "dbo.Answers", name: "Student_studentID", newName: "Student_studentNumber");
            RenameColumn(table: "dbo.Doubts", name: "Student_studentID", newName: "Student_studentNumber");
            RenameColumn(table: "dbo.Works", name: "Student_studentID", newName: "Student_studentNumber");
            RenameIndex(table: "dbo.Answers", name: "IX_Student_studentID", newName: "IX_Student_studentNumber");
            RenameIndex(table: "dbo.Doubts", name: "IX_Student_studentID", newName: "IX_Student_studentNumber");
            RenameIndex(table: "dbo.Works", name: "IX_Student_studentID", newName: "IX_Student_studentNumber");
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "studentNumber");
            AddForeignKey("dbo.Answers", "Student_studentNumber", "dbo.Students", "studentNumber");
            AddForeignKey("dbo.Doubts", "Student_studentNumber", "dbo.Students", "studentNumber");
            AddForeignKey("dbo.Works", "Student_studentNumber", "dbo.Students", "studentNumber");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "Student_studentNumber", "dbo.Students");
            DropForeignKey("dbo.Doubts", "Student_studentNumber", "dbo.Students");
            DropForeignKey("dbo.Answers", "Student_studentNumber", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "studentID");
            RenameIndex(table: "dbo.Works", name: "IX_Student_studentNumber", newName: "IX_Student_studentID");
            RenameIndex(table: "dbo.Doubts", name: "IX_Student_studentNumber", newName: "IX_Student_studentID");
            RenameIndex(table: "dbo.Answers", name: "IX_Student_studentNumber", newName: "IX_Student_studentID");
            RenameColumn(table: "dbo.Works", name: "Student_studentNumber", newName: "Student_studentID");
            RenameColumn(table: "dbo.Doubts", name: "Student_studentNumber", newName: "Student_studentID");
            RenameColumn(table: "dbo.Answers", name: "Student_studentNumber", newName: "Student_studentID");
            AddForeignKey("dbo.Works", "Student_studentID", "dbo.Students", "studentID");
            AddForeignKey("dbo.Doubts", "Student_studentID", "dbo.Students", "studentID");
            AddForeignKey("dbo.Answers", "Student_studentID", "dbo.Students", "studentID");
        }
    }
}
