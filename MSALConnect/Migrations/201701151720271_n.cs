namespace MSALConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Works", "nameWork", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Works", "nameWork");
        }
    }
}
