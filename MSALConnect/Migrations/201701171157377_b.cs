namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "student_studentNumber", "dbo.Students");
            DropIndex("dbo.Notifications", new[] { "student_studentNumber" });
            AddColumn("dbo.Works", "content", c => c.String());
            DropTable("dbo.Notifications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        notificationID = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        student_studentNumber = c.Int(),
                    })
                .PrimaryKey(t => t.notificationID);
            
            DropColumn("dbo.Works", "content");
            CreateIndex("dbo.Notifications", "student_studentNumber");
            AddForeignKey("dbo.Notifications", "student_studentNumber", "dbo.Students", "studentNumber");
        }
    }
}
