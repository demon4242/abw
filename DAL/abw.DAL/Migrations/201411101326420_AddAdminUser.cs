namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddAdminUser : DbMigration
	{
		public override void Up()
		{
			const string name = "admin";
			string password = "demon_4242".GetHashCode().ToString();
			string sql = string.Format("INSERT INTO Users (Name, Password) VALUES ('{0}', '{1}')", name, password);
			Sql(sql);
		}

		public override void Down()
		{
			Sql("DELETE FROM Users");
		}
	}
}
