namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNavigationPropertiestoclasses : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Assignment", "CourseID");
            CreateIndex("dbo.AssignmentMilestone", "AssignmentID");
            CreateIndex("dbo.Submission", "AssignmentMilestoneID");
            CreateIndex("dbo.Enrollment", "CourseID");
            CreateIndex("dbo.Enrollment", "UserID");
            AddForeignKey("dbo.Submission", "AssignmentMilestoneID", "dbo.AssignmentMilestone", "ID", cascadeDelete: true);
            AddForeignKey("dbo.AssignmentMilestone", "AssignmentID", "dbo.Assignment", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Assignment", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "UserID", "dbo.User", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "UserID", "dbo.User");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Assignment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.AssignmentMilestone", "AssignmentID", "dbo.Assignment");
            DropForeignKey("dbo.Submission", "AssignmentMilestoneID", "dbo.AssignmentMilestone");
            DropIndex("dbo.Enrollment", new[] { "UserID" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.Submission", new[] { "AssignmentMilestoneID" });
            DropIndex("dbo.AssignmentMilestone", new[] { "AssignmentID" });
            DropIndex("dbo.Assignment", new[] { "CourseID" });
        }
    }
}
