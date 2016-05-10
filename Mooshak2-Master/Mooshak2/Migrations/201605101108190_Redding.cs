namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Redding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "UserID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teachments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Teachments", "UserID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollments", new[] { "UserID_Id" });
            DropIndex("dbo.Teachments", new[] { "CourseID" });
            DropIndex("dbo.Teachments", new[] { "UserID_Id" });
            DropColumn("dbo.Courses", "Details");
            DropColumn("dbo.Enrollments", "UserID_Id");
            DropTable("dbo.Teachments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachments",
                c => new
                    {
                        TeachmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        UserID_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TeachmentID);
            
            AddColumn("dbo.Enrollments", "UserID_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Courses", "Details", c => c.String());
            CreateIndex("dbo.Teachments", "UserID_Id");
            CreateIndex("dbo.Teachments", "CourseID");
            CreateIndex("dbo.Enrollments", "UserID_Id");
            AddForeignKey("dbo.Teachments", "UserID_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Teachments", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollments", "UserID_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
