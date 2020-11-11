namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManufacturerId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        OperatingSystemId = c.Int(nullable: false),
                        RamInGb = c.Short(nullable: false),
                        HddInGb = c.Short(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Battery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WeightInKg = c.Int(nullable: false),
                        DimensionInInch = c.Int(nullable: false),
                        FrontCameraCount = c.Byte(nullable: false),
                        MainCameraCount = c.Byte(nullable: false),
                        FrontCameraPrecisonInPx = c.Short(nullable: false),
                        MainCameraPrecisonInPx = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.OS", t => t.OperatingSystemId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.MaterialId)
                .Index(t => t.ModelId)
                .Index(t => t.OperatingSystemId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneColors",
                c => new
                    {
                        Phone_Id = c.Int(nullable: false),
                        Color_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Phone_Id, t.Color_Id })
                .ForeignKey("dbo.Phones", t => t.Phone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.Color_Id, cascadeDelete: true)
                .Index(t => t.Phone_Id)
                .Index(t => t.Color_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "OperatingSystemId", "dbo.OS");
            DropForeignKey("dbo.Phones", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Phones", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Phones", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.PhoneColors", "Color_Id", "dbo.Colors");
            DropForeignKey("dbo.PhoneColors", "Phone_Id", "dbo.Phones");
            DropIndex("dbo.PhoneColors", new[] { "Color_Id" });
            DropIndex("dbo.PhoneColors", new[] { "Phone_Id" });
            DropIndex("dbo.Phones", new[] { "OperatingSystemId" });
            DropIndex("dbo.Phones", new[] { "ModelId" });
            DropIndex("dbo.Phones", new[] { "MaterialId" });
            DropIndex("dbo.Phones", new[] { "ManufacturerId" });
            DropTable("dbo.PhoneColors");
            DropTable("dbo.OS");
            DropTable("dbo.Models");
            DropTable("dbo.Materials");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Phones");
            DropTable("dbo.Colors");
        }
    }
}
