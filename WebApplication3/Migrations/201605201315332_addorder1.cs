namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorder1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producttest",
                c => new
                    {
                        ProductOrderID = c.String(nullable: false, maxLength: 128),
                        MemberID = c.String(),
                        ProductID = c.String(),
                        DateOrder = c.String(),
                        Adress = c.String(),
                        Quanlity = c.Int(nullable: false),
                        priceOfProduct = c.Double(nullable: false),
                        CostFormMountain = c.Double(nullable: false),
                        FreesTransfer = c.Double(nullable: false),
                        TotalPayment = c.String(),
                        ConfirmStatus = c.String(),
                        PayMentStatus = c.String(),
                        DeliveryStatus = c.String(),
                    })
                .PrimaryKey(t => t.ProductOrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Producttest");
        }
    }
}
