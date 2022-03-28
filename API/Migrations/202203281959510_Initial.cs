namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Data_city");
        }
        
        public override void Down()
        {
            
        }
    }
}
