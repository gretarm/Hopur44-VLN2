namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.AssignmentMilestone",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssignmentID = c.Int(nullable: false),
                        Title = c.String(),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assignment", t => t.AssignmentID, cascadeDelete: true)
                .Index(t => t.AssignmentID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "TeacherID", "dbo.Teacher");
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Assignment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.AssignmentMilestone", "AssignmentID", "dbo.Assignment");
            DropIndex("dbo.Enrollment", new[] { "StudentID" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.Course", new[] { "TeacherID" });
            DropIndex("dbo.AssignmentMilestone", new[] { "AssignmentID" });
            DropIndex("dbo.Assignment", new[] { "CourseID" });
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Course");
            DropTable("dbo.AssignmentMilestone");
            DropTable("dbo.Assignment");
        }
    }
}
