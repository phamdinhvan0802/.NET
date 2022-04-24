namespace CuoiKy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbs2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DichVus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDV = c.String(),
                        GiaDV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DungDVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KhachHangId = c.Int(nullable: false),
                        DichVuId = c.Int(nullable: false),
                        NgaySD = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DichVus", t => t.DichVuId, cascadeDelete: true)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHangId, cascadeDelete: true)
                .Index(t => t.KhachHangId)
                .Index(t => t.DichVuId);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hoten = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        Gioitinh = c.String(),
                        CMND = c.String(),
                        SDT = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenHD = c.String(),
                        PhongThueId = c.Int(nullable: false),
                        NhanVienId = c.Int(nullable: false),
                        NgaylapHD = c.DateTime(nullable: false),
                        Tongtien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhanViens", t => t.NhanVienId, cascadeDelete: true)
                .ForeignKey("dbo.PhongThues", t => t.PhongThueId, cascadeDelete: true)
                .Index(t => t.PhongThueId)
                .Index(t => t.NhanVienId);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotenNV = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        Gioitinh = c.String(),
                        CMND = c.String(),
                        SDT = c.String(),
                        Matkhau = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhongThues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KhachHangId = c.Int(nullable: false),
                        PhongId = c.Int(nullable: false),
                        NgayDen = c.DateTime(nullable: false),
                        NgayDi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHangId, cascadeDelete: true)
                .ForeignKey("dbo.Phongs", t => t.PhongId, cascadeDelete: true)
                .Index(t => t.KhachHangId)
                .Index(t => t.PhongId);
            
            CreateTable(
                "dbo.Phongs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Loaiphong = c.String(),
                        Giaphong = c.Int(nullable: false),
                        Tinhtrang = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "PhongThueId", "dbo.PhongThues");
            DropForeignKey("dbo.PhongThues", "PhongId", "dbo.Phongs");
            DropForeignKey("dbo.PhongThues", "KhachHangId", "dbo.KhachHangs");
            DropForeignKey("dbo.HoaDons", "NhanVienId", "dbo.NhanViens");
            DropForeignKey("dbo.DungDVs", "KhachHangId", "dbo.KhachHangs");
            DropForeignKey("dbo.DungDVs", "DichVuId", "dbo.DichVus");
            DropIndex("dbo.PhongThues", new[] { "PhongId" });
            DropIndex("dbo.PhongThues", new[] { "KhachHangId" });
            DropIndex("dbo.HoaDons", new[] { "NhanVienId" });
            DropIndex("dbo.HoaDons", new[] { "PhongThueId" });
            DropIndex("dbo.DungDVs", new[] { "DichVuId" });
            DropIndex("dbo.DungDVs", new[] { "KhachHangId" });
            DropTable("dbo.Phongs");
            DropTable("dbo.PhongThues");
            DropTable("dbo.NhanViens");
            DropTable("dbo.HoaDons");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DungDVs");
            DropTable("dbo.DichVus");
        }
    }
}
