using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddDefaultCars : DbMigration
	{
		private AbwDbContext _dbContext;

		public override void Up()
		{
			using (_dbContext = new AbwDbContext())
			{
				InsertCars("Audi", new List<string>
				{
					"100",
					"5000",
					"70",
					"80",
					"90",
					"A1",
					"A2",
					"A3",
					"A4",
					"A5",
					"A6",
					"A7",
					"A8",
					"Allroad",
					"Coupe",
					"Q3",
					"Q5",
					"Q7",
					"R8",
					"RS4",
					"RS6",
					"S2",
					"S3",
					"S4",
					"S5",
					"S6",
					"S8",
					"TT",
					"V8"
				});
				InsertCars("Volkswagen", new List<string>
				{
					"Beetle",
					"Bora",
					"Vento",
					"Gol",
					"Golf",
					"Derby",
					"Jetta",
					"Corrado",
					"Caddy",
					"Lupo",
					"New-Beetle",
					"Passat",
					"Polo",
					"Santana",
					"Scirocco",
					"Touareg",
					"Touran",
					"Phaeton",
					"Sharan",
					"EOS",
					"Tiguan",
					"Fox",
					"Golf Plus",
					"CC",
					"Amarok",
					"Routan"
				});
				InsertCars("Seat", new List<string>
				{
					"Altea",
					"Alhambra",
					"Arosa",
					"Ibiza",
					"Inca",
					"Cordoba",
					"Leon",
					"Malaga",
					"Marbella",
					"Terra",
					"Toledo",
					"Exeo"
				});
				InsertCars("Skoda", new List<string>
				{
					"1202",
					"Octavia",
					"Superb",
					"Fabia",
					"Favorit",
					"Felicia",
					"Forman",
					"Roomster",
					"Praktik",
					"Yeti"
				});
				InsertCars("Toyota", new List<string>
				{
					"RAV4"
				});
				InsertCars("Nissan", new List<string>
				{
					"X-Trail"
				});
				_dbContext.SaveChanges();
			}
		}

		public override void Down()
		{
			using (_dbContext = new AbwDbContext())
			{
				foreach (Car car in _dbContext.Cars)
				{
					_dbContext.Cars.Remove(car);
				}
				foreach (CarMake carMake in _dbContext.CarMakes)
				{
					_dbContext.CarMakes.Remove(carMake);
				}

				_dbContext.SaveChanges();
			}
		}

		private void InsertCars(string make, IEnumerable<string> models)
		{
			List<Car> cars = new List<Car>();
			foreach (string model in models)
			{
				Car car = new Car { Model = model };
				cars.Add(car);
			}

			CarMake carMake = new CarMake
			{
				Name = make,
				Cars = cars
			};

			_dbContext.CarMakes.Add(carMake);
		}
	}
}
