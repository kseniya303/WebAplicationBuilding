namespace Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMaterial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserMaterials",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.MaterialId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MaterialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.UserMaterials", "UserId", "dbo.Users");
            DropIndex("dbo.UserMaterials", new[] { "MaterialId" });
            DropIndex("dbo.UserMaterials", new[] { "UserId" });
            DropTable("dbo.UserMaterials");
        }
    }
}
