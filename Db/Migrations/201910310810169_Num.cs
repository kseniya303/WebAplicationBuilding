namespace Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Num : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "Num", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "Num");
        }
    }
}
