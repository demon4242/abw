using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.DAL.Repositories
{
	public class CarMakesRepository : Repository<CarMake>, ICarMakesRepository
	{
		public CarMakesRepository(DbContext dbContext)
			: base(dbContext)
		{
		}

		public override void Update(CarMake carMake)
		{
			CarMake originalCarMake = All.Single(m => m.Id == carMake.Id);
			ICollection<Car> originalCars = originalCarMake.Cars.ToList();
			foreach (Car originalCar in originalCars)
			{
				DbEntityEntry<Car> entry = DbContext.Entry(originalCar);
				Car car = carMake.Cars.SingleOrDefault(m => m.Id == originalCar.Id);
				// car has been deleted
				if (car == null)
				{
					entry.State = EntityState.Deleted;
				}
				// car has been modified
				else
				{
					entry.CurrentValues.SetValues(car);
				}
			}
			foreach (Car car in carMake.Cars)
			{
				// car has been added
				if (originalCars.SingleOrDefault(m => m.Id == car.Id) == null)
				{
					originalCarMake.Cars.Add(car);
				}
			}
			DbEntityEntry<CarMake> originalCarMakeEntry = DbContext.Entry(originalCarMake);
			originalCarMakeEntry.CurrentValues.SetValues(carMake);
		}
	}
}
