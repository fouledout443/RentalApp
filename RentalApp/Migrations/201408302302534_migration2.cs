namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressNickName = c.String(),
                        AddressType = c.Int(nullable: false),
                        HouseNumber = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        EmployerID = c.Int(nullable: false, identity: true),
                        EmployerName = c.String(),
                        Location = c.String(),
                        ManagerName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        PositionTitle = c.String(),
                        JobDescription = c.String(),
                        ReasonForLeaving = c.String(),
                        DurationOfEmployment = c.DateTime(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployerID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Addresses", "UserID", "dbo.Users");
            DropIndex("dbo.Employers", new[] { "User_UserID" });
            DropIndex("dbo.Addresses", new[] { "UserID" });
            DropTable("dbo.Employers");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
