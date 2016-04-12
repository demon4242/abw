namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddAdminUser : DbMigration
	{
		public override void Up()
		{
			const string name = "admin";
			string password = "demon_4242".GetHashCode().ToString();
			string sql = $"INSERT INTO Users (Name, Password) VALUES ('{name}', '{password}')";
			Sql(sql);
		}

		public override void Down()
		{
			Sql("DELETE FROM Users");
		}
	}
}
