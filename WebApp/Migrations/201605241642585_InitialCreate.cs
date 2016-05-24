namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeSheet",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Hours = c.Int(nullable: false),
                        Description = c.String(),
                        Volunteer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Volunteer", t => t.Volunteer_Id)
                .Index(t => t.Volunteer_Id);
            
            CreateTable(
                "dbo.Volunteer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Team = c.String(),
                        Employer = c.String(),
                        State = c.String(),
                        OrientationDate = c.DateTime(),
                        MediaOrientationDate = c.DateTime(),
                        GoogleDocsOrientationDate = c.DateTime(),
                        SdwtOrientationDate = c.DateTime(),
                        ToolbarOrientationDate = c.DateTime(),
                        CaseMgmtOrientationDate = c.DateTime(),
                        EarthquakeOrientationDate = c.DateTime(),
                        GoogleEarthOrientationDate = c.DateTime(),
                        PublishingOrientationDate = c.DateTime(),
                        TshirtSize = c.String(),
                        Name_First = c.String(),
                        Name_Last = c.String(),
                        Email_Social = c.String(),
                        Email_Contact = c.String(),
                        Email_GoogleDocs = c.String(),
                        SkypeId = c.String(),
                        TwitterId = c.String(),
                        PhoneNumber_Primary = c.String(),
                        PhoneNumber_Mobile = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                        PostalCode = c.String(),
                        CountryRegion = c.String(),
                        CountryRegionOfCitizenship = c.String(),
                        BirthMonth = c.Int(),
                        BirthDay = c.Int(),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        imageUri = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSheet", "Volunteer_Id", "dbo.Volunteer");
            DropIndex("dbo.TimeSheet", new[] { "Volunteer_Id" });
            DropTable("dbo.Volunteer");
            DropTable("dbo.TimeSheet");
        }
    }
}
