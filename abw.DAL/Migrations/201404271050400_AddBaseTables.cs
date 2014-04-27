namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddBaseTables : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.CarMakes",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(nullable: false, maxLength: 255),
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.Cars",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						MakeId = c.Int(nullable: false),
						Model = c.String(nullable: false, maxLength: 255),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.CarMakes", t => t.MakeId, cascadeDelete: true)
				.Index(t => t.MakeId);

			CreateTable(
				"dbo.MyCars",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						CarId = c.Int(nullable: false),
						Year = c.Int(nullable: false),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
				.Index(t => t.CarId);

		}

		public override void Down()
		{
			DropIndex("dbo.MyCars", new[] { "CarId" });
			DropIndex("dbo.Cars", new[] { "MakeId" });
			DropForeignKey("dbo.MyCars", "CarId", "dbo.Cars");
			DropForeignKey("dbo.Cars", "MakeId", "dbo.CarMakes");
			DropTable("dbo.MyCars");
			DropTable("dbo.Cars");
			DropTable("dbo.CarMakes");
		}
	}
}
