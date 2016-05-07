namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubmissionEditedClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignmentMilestone", "AssignmentID", "dbo.Assignment");
            DropForeignKey("dbo.Assignment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "UserID", "dbo.User");
            DropIndex("dbo.Assignment", new[] { "CourseID" });
            DropIndex("dbo.AssignmentMilestone", new[] { "AssignmentID" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.Enrollment", new[] { "UserID" });
            CreateTable(
                "dbo.Submission",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AssignmentMilestoneID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.User", "Name", c => c.String());
            DropColumn("dbo.User", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Title", c => c.String());
            DropColumn("dbo.User", "Name");
            DropTable("dbo.Submission");
            CreateIndex("dbo.Enrollment", "UserID");
            CreateIndex("dbo.Enrollment", "CourseID");
            CreateIndex("dbo.AssignmentMilestone", "AssignmentID");
            CreateIndex("dbo.Assignment", "CourseID");
            AddForeignKey("dbo.Enrollment", "UserID", "dbo.User", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Assignment", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.AssignmentMilestone", "AssignmentID", "dbo.Assignment", "ID", cascadeDelete: true);
        }
    }
}
