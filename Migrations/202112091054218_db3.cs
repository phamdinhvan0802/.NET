namespace CuoiKy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhongThues", "NgayDen", c => c.DateTime());
            AlterColumn("dbo.PhongThues", "NgayDi", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhongThues", "NgayDi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PhongThues", "NgayDen", c => c.DateTime(nullable: false));
        }
    }
}
