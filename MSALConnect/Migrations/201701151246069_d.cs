namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Doubts", new[] { "Course_id" });
            CreateIndex("dbo.Doubts", "course_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Doubts", new[] { "course_id" });
            CreateIndex("dbo.Doubts", "Course_id");
        }
    }
}
