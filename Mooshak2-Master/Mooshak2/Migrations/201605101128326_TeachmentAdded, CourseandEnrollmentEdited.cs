namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeachmentAddedCourseandEnrollmentEdited : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachments",
                c => new
                    {
                        TeachmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        UserID_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TeachmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID_Id)
                .Index(t => t.CourseID)
                .Index(t => t.UserID_Id);
            
            AddColumn("dbo.Courses", "Details", c => c.String());
            AddColumn("dbo.Enrollments", "UserID_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Enrollments", "UserID_Id");
            AddForeignKey("dbo.Enrollments", "UserID_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachments", "UserID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teachments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "UserID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Teachments", new[] { "UserID_Id" });
            DropIndex("dbo.Teachments", new[] { "CourseID" });
            DropIndex("dbo.Enrollments", new[] { "UserID_Id" });
            DropColumn("dbo.Enrollments", "UserID_Id");
            DropColumn("dbo.Courses", "Details");
            DropTable("dbo.Teachments");
        }
    }
}
