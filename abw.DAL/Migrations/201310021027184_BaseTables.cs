namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class BaseTables : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Cars",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						Make = c.String(nullable: false, maxLength: 255),
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.CarModels",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						Name = c.String(nullable: false, maxLength: 255),
						CarId = c.Long(nullable: false),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
				.Index(t => t.CarId);

			CreateTable(
				"dbo.MyCars",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						CarModelId = c.Long(nullable: false),
						Year = c.Int(nullable: false),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
				.Index(t => t.CarModelId);

		}

		public override void Down()
		{
			DropIndex("dbo.MyCars", new[] { "CarModelId" });
			DropIndex("dbo.CarModels", new[] { "CarId" });
			DropForeignKey("dbo.MyCars", "CarModelId", "dbo.CarModels");
			DropForeignKey("dbo.CarModels", "CarId", "dbo.Cars");
			DropTable("dbo.MyCars");
			DropTable("dbo.CarModels");
			DropTable("dbo.Cars");
		}
	}
}
