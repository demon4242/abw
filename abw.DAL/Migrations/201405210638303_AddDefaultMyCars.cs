using System.Linq;
using abw.DAL.Entities;

namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddDefaultMyCars : DbMigration
	{
		private AbwDbContext _dbContext;

		public override void Up()
		{
			using (_dbContext = new AbwDbContext())
			{
				AddMyCar("Audi", "A6", 1997);

				AddMyCar("Seat", "Altea", 2006);
				AddMyCar("Seat", "Arosa", 2001);
				AddMyCar("Seat", "Cordoba", 1998);
				AddMyCar("Seat", "Cordoba", 2001);
				AddMyCar("Seat", "Inca", 2002);
				AddMyCar("Seat", "Ibiza", 2002);
				AddMyCar("Seat", "Toledo", 2001);

				AddMyCar("Skoda", "Fabia", 2002);
				AddMyCar("Skoda", "Felicia", 1999);
				AddMyCar("Skoda", "Octavia", 2002);
				AddMyCar("Skoda", "Superb", 2006);

				AddMyCar("Nissan", "X-Trail", 2003);
				AddMyCar("Toyota", "RAV4", 2002);

				AddMyCar("Volkswagen", "Caddy", 2002);
				AddMyCar("Volkswagen", "Lupo", 2001);
				AddMyCar("Volkswagen", "Polo", 2001);
				AddMyCar("Volkswagen", "Polo", 2003);

				_dbContext.SaveChanges();
			}
		}

		public override void Down()
		{
			using (_dbContext = new AbwDbContext())
			{
				foreach (MyCar myCar in _dbContext.MyCars)
				{
					_dbContext.MyCars.Remove(myCar);
				}
				_dbContext.SaveChanges();
			}
		}

		private void AddMyCar(string make, string model, int year)
		{
			Car car = _dbContext.Cars.SingleOrDefault(m => m.Make.Name == make && m.Model == model);
			if (car != null)
			{
				MyCar myCar = new MyCar();
				myCar.CarId = car.Id;
				myCar.Year = year;
				_dbContext.MyCars.Add(myCar);
			}
		}
	}
}
