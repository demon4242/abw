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

		public DbSet<Car> Cars { get; set; }

		public DbSet<CarModel> CarModels { get; set; }

		public DbSet<MyCar> MyCars { get; set; }
	}
}
