namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deliveryMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        deliveryId = c.Int(nullable: false, identity: true),
                        totalPrice = c.Int(nullable: false),
                        paymentType = c.String(nullable: false),
                        fullName = c.String(nullable: false),
                        address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.deliveryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Deliveries");
        }
    }
}
