namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingResidenceFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residence", "LandLord_LandLordId", c => c.Int());
            CreateIndex("dbo.Residence", "LandLord_LandLordId");
            AddForeignKey("dbo.Residence", "LandLord_LandLordId", "dbo.LandLord", "LandLordId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Residence", "LandLord_LandLordId", "dbo.LandLord");
            DropIndex("dbo.Residence", new[] { "LandLord_LandLordId" });
            DropColumn("dbo.Residence", "LandLord_LandLordId");
        }
    }
}
