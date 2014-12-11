using abw.DAL.Entities;

namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddAdminUser : DbMigration
	{
		public override void Up()
		{
			using (AbwDbContext dbContext = new AbwDbContext())
			{
				dbContext.Users.Add(new User
				{
					Name = "admin",
					Password = "demon_4242".GetHashCode().ToString()
				});
				dbContext.SaveChanges();
			}
		}

		public override void Down()
		{
		}
	}
}
