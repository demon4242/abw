using System.Data.Entity;
using abw.DAL.Entities;

namespace abw.DAL
{
	public class AbwDbContext : DbContext
	{
		public AbwDbContext()
			: base("abw")
		{
		}

		public DbSet<CarMake> CarMakes { get; set; }

		public DbSet<Car> Cars { get; set; }

		public DbSet<MyCar> MyCars { get; set; }

		public DbSet<User> Users { get; set; }
	}
}
