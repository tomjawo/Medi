namespace Medi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingExaminationModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Examinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExaminationTape = c.Int(nullable: false),
                        OrderedDate = c.DateTime(nullable: false),
                        PreparedDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        OrderedBy_Id = c.String(maxLength: 128),
                        PreparedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OrderedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PreparedBy_Id)
                .Index(t => t.OrderedBy_Id)
                .Index(t => t.PreparedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Examinations", "PreparedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Examinations", "OrderedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Examinations", new[] { "PreparedBy_Id" });
            DropIndex("dbo.Examinations", new[] { "OrderedBy_Id" });
            DropTable("dbo.Examinations");
        }
    }
}
