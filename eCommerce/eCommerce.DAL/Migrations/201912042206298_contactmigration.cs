namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        contactId = c.Int(nullable: false, identity: true),
                        fullName = c.String(),
                        email = c.String(),
                        message = c.String(),
                    })
                .PrimaryKey(t => t.contactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
