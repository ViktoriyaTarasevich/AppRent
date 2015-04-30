namespace AppRent.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLinkBetweenApartemntAndHouse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "House_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Apartments", "House_Id");
            AddForeignKey("dbo.Apartments", "House_Id", "dbo.Houses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apartments", "House_Id", "dbo.Houses");
            DropIndex("dbo.Apartments", new[] { "House_Id" });
            DropColumn("dbo.Apartments", "House_Id");
        }
    }
}
