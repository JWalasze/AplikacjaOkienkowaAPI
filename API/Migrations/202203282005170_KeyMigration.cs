namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data_city",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    city_name = c.String(),
                    timezone = c.String(),
                    country_code = c.String(),
                    aqi = c.Int(nullable: false),
                    co = c.Double(nullable: false),
                    o3 = c.Double(nullable: false),
                    so2 = c.Double(nullable: false),
                    no2 = c.Double(nullable: false),
                    _date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.Data_city");
        }
    }
}
