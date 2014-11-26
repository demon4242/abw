using System.Data.Entity;
using abw.DAL.Migrations;

namespace abw.DAL
{
	public class AbwDbInitializer : MigrateDatabaseToLatestVersion<AbwDbContext, AbwDbMigrationsConfiguration>
	{
	}
}
