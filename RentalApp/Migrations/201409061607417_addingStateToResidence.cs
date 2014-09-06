namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingStateToResidence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residence", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Residence", "State");
        }
    }
}
