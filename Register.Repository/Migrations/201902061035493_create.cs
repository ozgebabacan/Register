namespace Register.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        City_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        MobilePhone = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        City_Id = c.Long(nullable: false),
                        District_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.District", t => t.District_Id, cascadeDelete: true)
                .Index(t => t.City_Id)
                .Index(t => t.District_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "District_Id", "dbo.District");
            DropForeignKey("dbo.Student", "City_Id", "dbo.City");
            DropForeignKey("dbo.District", "City_Id", "dbo.City");
            DropIndex("dbo.Student", new[] { "District_Id" });
            DropIndex("dbo.Student", new[] { "City_Id" });
            DropIndex("dbo.District", new[] { "City_Id" });
            DropTable("dbo.Student");
            DropTable("dbo.District");
            DropTable("dbo.City");
        }
    }
}
