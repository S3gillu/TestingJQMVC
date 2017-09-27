namespace TestingJQMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Test.PupilDetails",
                c => new
                    {
                        PupilId = c.Int(nullable: false),
                        CurrentAddress = c.String(),
                        Stream = c.String(),
                        FathersName = c.String(),
                        PermanentAddress = c.String(),
                    })
                .PrimaryKey(t => t.PupilId)
                .ForeignKey("Test.Pupils", t => t.PupilId)
                .Index(t => t.PupilId);
            
            CreateTable(
                "Test.Pupils",
                c => new
                    {
                        PupilId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Age = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PupilId);
            
            CreateTable(
                "Test.ViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Age = c.Long(nullable: false),
                        CurrentAddress = c.String(),
                        Stream = c.String(),
                        FathersName = c.String(),
                        PermanentAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Test.PupilDetails", "PupilId", "Test.Pupils");
            DropIndex("Test.PupilDetails", new[] { "PupilId" });
            DropTable("Test.ViewModels");
            DropTable("Test.Pupils");
            DropTable("Test.PupilDetails");
        }
    }
}
