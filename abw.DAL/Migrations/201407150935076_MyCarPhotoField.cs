namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class MyCarPhotoField : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.MyCars", "Photo", c => c.String(nullable: false));
			AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
			AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
		}

		public override void Down()
		{
			AlterColumn("dbo.Users", "Password", c => c.String());
			AlterColumn("dbo.Users", "Name", c => c.String());
			DropColumn("dbo.MyCars", "Photo");
		}
	}
}
