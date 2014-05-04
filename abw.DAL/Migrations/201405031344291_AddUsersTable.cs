namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddUsersTable : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Users",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(),
						Password = c.String(),
					})
				.PrimaryKey(t => t.Id);
		}

		public override void Down()
		{
			DropTable("dbo.Users");
		}
	}
}
