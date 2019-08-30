namespace DemoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "City_Id", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "City_Id" });
            RenameColumn(table: "dbo.Users", name: "City_Id", newName: "CityID");
            AddColumn("dbo.Users", "Avatar", c => c.String());
            AddColumn("dbo.Users", "CountryID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "StateID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "CountryID");
            CreateIndex("dbo.Users", "StateID");
            CreateIndex("dbo.Users", "CityID");
            AddForeignKey("dbo.Users", "CountryID", "dbo.Countries", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "StateID", "dbo.States", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "CityID", "dbo.Cities", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Users", "StateID", "dbo.States");
            DropForeignKey("dbo.Users", "CountryID", "dbo.Countries");
            DropIndex("dbo.Users", new[] { "CityID" });
            DropIndex("dbo.Users", new[] { "StateID" });
            DropIndex("dbo.Users", new[] { "CountryID" });
            AlterColumn("dbo.Users", "CityID", c => c.Int());
            AlterColumn("dbo.Users", "DateOfBirth", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "StateID");
            DropColumn("dbo.Users", "CountryID");
            DropColumn("dbo.Users", "Avatar");
            RenameColumn(table: "dbo.Users", name: "CityID", newName: "City_Id");
            CreateIndex("dbo.Users", "City_Id");
            AddForeignKey("dbo.Users", "City_Id", "dbo.Cities", "Id");
        }
    }
}
