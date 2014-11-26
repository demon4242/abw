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
					// todo: do not use hash code for encryption
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
