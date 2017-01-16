namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        notificationID = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        student_studentNumber = c.Int(),
                    })
                .PrimaryKey(t => t.notificationID)
                .ForeignKey("dbo.Students", t => t.student_studentNumber)
                .Index(t => t.student_studentNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "student_studentNumber", "dbo.Students");
            DropIndex("dbo.Notifications", new[] { "student_studentNumber" });
            DropTable("dbo.Notifications");
        }
    }
}
