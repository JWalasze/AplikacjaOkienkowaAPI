namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Basic_cities",
                c => new
                    {
                        CityName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CityName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Basic_cities");
        }
    }
}
