
namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newInit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "AssignmentMilestoneID", "dbo.AssignmentMilestones");
            DropIndex("dbo.Submissions", new[] { "AssignmentMilestoneID" });
            AddColumn("dbo.AssignmentMilestones", "MaxHandIns", c => c.Int(nullable: false));
            AddColumn("dbo.AssignmentMilestones", "BestSubmission_ID", c => c.Int());
            AddColumn("dbo.Submissions", "AssignmentMilestone_ID", c => c.Int());
            CreateIndex("dbo.AssignmentMilestones", "BestSubmission_ID");
            CreateIndex("dbo.Submissions", "AssignmentMilestone_ID");
            AddForeignKey("dbo.AssignmentMilestones", "BestSubmission_ID", "dbo.Submissions", "ID");
            AddForeignKey("dbo.Submissions", "AssignmentMilestone_ID", "dbo.AssignmentMilestones", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "AssignmentMilestone_ID", "dbo.AssignmentMilestones");
            DropForeignKey("dbo.AssignmentMilestones", "BestSubmission_ID", "dbo.Submissions");
            DropIndex("dbo.Submissions", new[] { "AssignmentMilestone_ID" });
            DropIndex("dbo.AssignmentMilestones", new[] { "BestSubmission_ID" });
            DropColumn("dbo.Submissions", "AssignmentMilestone_ID");
            DropColumn("dbo.AssignmentMilestones", "BestSubmission_ID");
            DropColumn("dbo.AssignmentMilestones", "MaxHandIns");
            CreateIndex("dbo.Submissions", "AssignmentMilestoneID");
            AddForeignKey("dbo.Submissions", "AssignmentMilestoneID", "dbo.AssignmentMilestones", "ID", cascadeDelete: true);
        }
    }
}
