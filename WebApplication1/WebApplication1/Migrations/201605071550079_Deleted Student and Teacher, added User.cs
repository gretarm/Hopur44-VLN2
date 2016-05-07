namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedStudentandTeacheraddedUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Course", "TeacherID", "dbo.Teacher");
            DropIndex("dbo.Course", new[] { "TeacherID" });
            DropIndex("dbo.Enrollment", new[] { "StudentID" });
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Enrollment", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollment", "UserID");
            AddForeignKey("dbo.Enrollment", "UserID", "dbo.User", "ID", cascadeDelete: true);
            DropColumn("dbo.Course", "TeacherID");
            DropColumn("dbo.Enrollment", "StudentID");
            DropTable("dbo.Student");
            DropTable("dbo.Teacher");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Enrollment", "StudentID", c => c.Int(nullable: false));
            AddColumn("dbo.Course", "TeacherID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Enrollment", "UserID", "dbo.User");
            DropIndex("dbo.Enrollment", new[] { "UserID" });
            DropColumn("dbo.Enrollment", "UserID");
            DropTable("dbo.User");
            CreateIndex("dbo.Enrollment", "StudentID");
            CreateIndex("dbo.Course", "TeacherID");
            AddForeignKey("dbo.Course", "TeacherID", "dbo.Teacher", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "StudentID", "dbo.Student", "ID", cascadeDelete: true);
        }
    }
}
