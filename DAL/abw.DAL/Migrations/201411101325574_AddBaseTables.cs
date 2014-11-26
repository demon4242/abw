namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddBaseTables : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Cars",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Make = c.String(nullable: false, maxLength: 255),
						Model = c.String(nullable: false, maxLength: 255),
						YearFrom = c.Int(nullable: false),
						YearTo = c.Int(),
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.Users",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(nullable: false),
						Password = c.String(nullable: false),
					})
				.PrimaryKey(t => t.Id);

		}

		public override void Down()
		{
			DropTable("dbo.Users");
			DropTable("dbo.Cars");
		}
	}
}
