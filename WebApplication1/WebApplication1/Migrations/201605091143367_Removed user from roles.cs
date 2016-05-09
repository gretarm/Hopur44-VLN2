namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removeduserfromroles : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "RoleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "RoleID", c => c.Int(nullable: false));
        }
    }
}
