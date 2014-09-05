namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingAddresses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Address", "UserInfo_UserInfoID", "dbo.UserInfo");
            DropIndex("dbo.Address", new[] { "UserInfo_UserInfoID" });
            CreateTable(
                "dbo.Residence",
                c => new
                    {
                        ResidenceID = c.Int(nullable: false, identity: true),
                        ResidenceNickName = c.String(),
                        ResidenceType = c.Int(nullable: false),
                        HouseNumber = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Duration = c.String(),
                        CurrentAddress = c.Boolean(nullable: false),
                        UserInfo_UserInfoID = c.Int(),
                    })
                .PrimaryKey(t => t.ResidenceID)
                .ForeignKey("dbo.UserInfo", t => t.UserInfo_UserInfoID)
                .Index(t => t.UserInfo_UserInfoID);
            
            DropColumn("dbo.UserInfo", "LandLordId");
            DropTable("dbo.Address");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressNickName = c.String(),
                        AddressType = c.Int(nullable: false),
                        HouseNumber = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Duration = c.String(),
                        UserInfo_UserInfoID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressID);
            
            AddColumn("dbo.UserInfo", "LandLordId", c => c.Int());
            DropForeignKey("dbo.Residence", "UserInfo_UserInfoID", "dbo.UserInfo");
            DropIndex("dbo.Residence", new[] { "UserInfo_UserInfoID" });
            DropTable("dbo.Residence");
            CreateIndex("dbo.Address", "UserInfo_UserInfoID");
            AddForeignKey("dbo.Address", "UserInfo_UserInfoID", "dbo.UserInfo", "UserInfoID");
        }
    }
}
