namespace Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Materials", "UnitId", "dbo.Units");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Materials", new[] { "UnitId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Units");
            DropTable("dbo.Materials");
        }
    }
}
