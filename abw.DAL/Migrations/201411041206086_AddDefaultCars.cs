using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using abw.DAL.Entities;

namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddDefaultCars : DbMigration
	{
		private readonly List<string> _cars = new List<string>
		{
			"Nissan X-Trail 2003",
			"Seat Altea 2006",
			"Seat Arosa 2000",
			"Seat Cordoba 1998",
			"Seat Cordoba 2001",
			"Seat Ibiza 2002",
			"Seat Inca 2002",
			"Seat Toledo 2001",
			"Skoda Fabia 2002",
			"Skoda Felicia 1999",
			"Skoda Octavia 2002",
			"Skoda Superb 2006",
			"Toyota RAV4 2002",
			"Volkswagen Caddy 2002",
			"Volkswagen Lupo 2001",
			"Volkswagen Polo 2001",
			"Volkswagen Polo 2003",
			"Volkswagen Polo 2008"
		};

		public override void Up()
		{
			using (AbwDbContext dbContext = new AbwDbContext())
			{
				foreach (string carString in _cars)
				{
					Car car = CreateCar(carString);
					dbContext.Cars.Add(car);
				}
				dbContext.SaveChanges();
			}
		}

		public override void Down()
		{
			using (AbwDbContext dbContext = new AbwDbContext())
			{
				foreach (Car car in dbContext.Cars)
				{
					DbEntityEntry<Car> dbEntityEntry = dbContext.Entry(car);
					dbEntityEntry.State = EntityState.Deleted;
				}
				dbContext.SaveChanges();
			}
		}

		private Car CreateCar(string carString)
		{
			string[] parts = carString.Split(' ');

			string make = parts[0];
			string model = parts[1];
			int year = int.Parse(parts[2]);

			Car car = new Car
			{
				Make = make,
				Model = model,
				Year = year
			};
			return car;
		}
	}
}
