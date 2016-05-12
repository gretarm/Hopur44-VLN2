namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFileSubmissionFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubmissionFiles",
                c => new
                    {
                        SubmissionFileID = c.Int(nullable: false, identity: true),
                        FileID = c.Int(nullable: false),
                        SubmissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionFileID)
                .ForeignKey("dbo.Files", t => t.FileID, cascadeDelete: true)
                .ForeignKey("dbo.Submissions", t => t.SubmissionID, cascadeDelete: true)
                .Index(t => t.FileID)
                .Index(t => t.SubmissionID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PathToFile = c.String(),
                    })
                .PrimaryKey(t => t.FileID);
            
            AddColumn("dbo.AssignmentMilestones", "BestSubmission", c => c.String());
            AddColumn("dbo.Submissions", "UserID_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Submissions", "UserID_Id");
            AddForeignKey("dbo.Submissions", "UserID_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "UserID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubmissionFiles", "SubmissionID", "dbo.Submissions");
            DropForeignKey("dbo.SubmissionFiles", "FileID", "dbo.Files");
            DropIndex("dbo.SubmissionFiles", new[] { "SubmissionID" });
            DropIndex("dbo.SubmissionFiles", new[] { "FileID" });
            DropIndex("dbo.Submissions", new[] { "UserID_Id" });
            DropColumn("dbo.Submissions", "UserID_Id");
            DropColumn("dbo.AssignmentMilestones", "BestSubmission");
            DropTable("dbo.Files");
            DropTable("dbo.SubmissionFiles");
        }
    }
}
