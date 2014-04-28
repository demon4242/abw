using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using abw.DAL.Entities;

namespace abw.DAL.Migrations
{
	public class AbwDbMigrationsConfiguration : DbMigrationsConfiguration<AbwDbContext>
	{
		public AbwDbMigrationsConfiguration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(AbwDbContext context)
		{
			CarMake audi = new CarMake
			{
				Name = "Audi",
				Cars = new Collection<Car>
				{
					new Car{ Model = "A1" },
					new Car{ Model = "A3" },
					new Car{ Model = "A4" },
					new Car{ Model = "A5" },
					new Car{ Model = "A6" },
					new Car{ Model = "A7" },
					new Car{ Model = "A8" },
					new Car{ Model = "Q3" },
					new Car{ Model = "Q5" },
					new Car{ Model = "Q7" },
					new Car{ Model = "R8" },
					new Car{ Model = "RS" },
					new Car{ Model = "TT" },
					new Car{ Model = "80" },
					new Car{ Model = "100" }
				}
			};

			CarMake volkswagen = new CarMake
			{
				Name = "Volkswagen",
				Cars = new Collection<Car>
				{
					new Car{ Model = "Golf" },
					new Car{ Model = "Passat" },
					new Car{ Model = "Tiguan" },
					new Car{ Model = "Touareg" }
				}
			};

			context.CarMakes.Add(audi);
			context.CarMakes.Add(volkswagen);
		}
	}
}
