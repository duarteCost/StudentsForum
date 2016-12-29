namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Degree_degreeID", c => c.Int());
            AddColumn("dbo.Works", "Course_id", c => c.Int());
            CreateIndex("dbo.Works", "Course_id");
            CreateIndex("dbo.Students", "Degree_degreeID");
            AddForeignKey("dbo.Works", "Course_id", "dbo.Courses", "id");
            AddForeignKey("dbo.Students", "Degree_degreeID", "dbo.Degrees", "degreeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Degree_degreeID", "dbo.Degrees");
            DropForeignKey("dbo.Works", "Course_id", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Degree_degreeID" });
            DropIndex("dbo.Works", new[] { "Course_id" });
            DropColumn("dbo.Works", "Course_id");
            DropColumn("dbo.Students", "Degree_degreeID");
        }
    }
}
