namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddcheck : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckOutOrder",
                c => new
                    {
                        CheckOutOrderID = c.String(nullable: false, maxLength: 128),
                        MemberID = c.String(),
                        ProductID = c.String(),
                        DateOrder = c.String(),
                        Adress = c.String(),
                        priceOfProduct = c.String(),
                        CostFormMountain = c.String(),
                        FreesTransfer = c.String(),
                        TotalPayment = c.String(),
                        ConfirmStatus = c.String(),
                        PayMentStatus = c.String(),
                        DeliveryStatus = c.String(),
                    })
                .PrimaryKey(t => t.CheckOutOrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CheckOutOrder");
        }
    }
}
