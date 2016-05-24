namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includeEmployerMatchFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteer", "EmployerOffersMatch", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteer", "EmployerOffersMatch");
        }
    }
}
