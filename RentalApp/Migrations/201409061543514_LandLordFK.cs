namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LandLordFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Residence", name: "LandLord_LandLordId", newName: "Residence");
            RenameIndex(table: "dbo.Residence", name: "IX_LandLord_LandLordId", newName: "IX_Residence");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Residence", name: "IX_Residence", newName: "IX_LandLord_LandLordId");
            RenameColumn(table: "dbo.Residence", name: "Residence", newName: "LandLord_LandLordId");
        }
    }
}
