namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        orderID = c.String(nullable: false, maxLength: 128),
                        MemberID = c.String(),
                        PaymentID = c.String(),
                        ProductID = c.String(),
                        DateOrder = c.String(),
                        Productprice = c.String(),
                        Addresss = c.String(),
                        Costformountain = c.String(),
                        FreesToHome = c.String(),
                        Totalpayment = c.String(),
                    })
                .PrimaryKey(t => t.orderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Order");
        }
    }
}
