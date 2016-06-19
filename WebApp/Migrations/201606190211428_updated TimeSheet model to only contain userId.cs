namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTimeSheetmodeltoonlycontainuserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeSheet", "Volunteer_Id", "dbo.Volunteer");
            DropIndex("dbo.TimeSheet", new[] { "Volunteer_Id" });
            AddColumn("dbo.TimeSheet", "volunteerId", c => c.String());
            DropColumn("dbo.TimeSheet", "Volunteer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeSheet", "Volunteer_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.TimeSheet", "volunteerId");
            CreateIndex("dbo.TimeSheet", "Volunteer_Id");
            AddForeignKey("dbo.TimeSheet", "Volunteer_Id", "dbo.Volunteer", "Id");
        }
    }
}
