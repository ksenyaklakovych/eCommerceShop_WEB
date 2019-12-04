namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        productId = c.Int(),
                        userId = c.Int(),
                        message = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.commentId)
                .ForeignKey("dbo.Products", t => t.productId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.productId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50, unicode: false),
                        price = c.Int(nullable: false),
                        category = c.String(nullable: false, maxLength: 50, unicode: false),
                        commentsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.productId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        userId = c.Int(),
                        productId = c.Int(),
                        quantity = c.Int(nullable: false),
                        payed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.orderId)
                .ForeignKey("dbo.Products", t => t.productId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(nullable: false, maxLength: 50, unicode: false),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.Rights",
                c => new
                    {
                        rightId = c.Int(nullable: false, identity: true),
                        productId = c.Int(),
                        userId = c.Int(),
                        roleId = c.Int(),
                    })
                .PrimaryKey(t => t.rightId)
                .ForeignKey("dbo.Products", t => t.productId)
                .ForeignKey("dbo.Roles", t => t.roleId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.productId)
                .Index(t => t.userId)
                .Index(t => t.roleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        roleId = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.roleId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        rateID = c.Int(nullable: false, identity: true),
                        productId = c.Int(),
                        rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.rateID)
                .ForeignKey("dbo.Products", t => t.productId)
                .Index(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "productId", "dbo.Products");
            DropForeignKey("dbo.Rights", "userId", "dbo.Users");
            DropForeignKey("dbo.Rights", "roleId", "dbo.Roles");
            DropForeignKey("dbo.Rights", "productId", "dbo.Products");
            DropForeignKey("dbo.Orders", "userId", "dbo.Users");
            DropForeignKey("dbo.Comments", "userId", "dbo.Users");
            DropForeignKey("dbo.Orders", "productId", "dbo.Products");
            DropForeignKey("dbo.Comments", "productId", "dbo.Products");
            DropIndex("dbo.Rates", new[] { "productId" });
            DropIndex("dbo.Rights", new[] { "roleId" });
            DropIndex("dbo.Rights", new[] { "userId" });
            DropIndex("dbo.Rights", new[] { "productId" });
            DropIndex("dbo.Orders", new[] { "productId" });
            DropIndex("dbo.Orders", new[] { "userId" });
            DropIndex("dbo.Comments", new[] { "userId" });
            DropIndex("dbo.Comments", new[] { "productId" });
            DropTable("dbo.Rates");
            DropTable("dbo.Roles");
            DropTable("dbo.Rights");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Comments");
        }
    }
}
