namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class depricatingtheoffersMatchbooleanflagforemployer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Volunteer", "EmployerOffersMatch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Volunteer", "EmployerOffersMatch", c => c.Boolean(nullable: false));
        }
    }
}
