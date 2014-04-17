using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.DAL.Repositories
{
	public class CarsRepository : Repository<Car>, ICarsRepository
	{
		public CarsRepository(DbContext dbContext)
			: base(dbContext)
		{
		}

		public override void Update(Car car)
		{
			Car originalCar = All.Single(m => m.Id == car.Id);
			ICollection<CarModel> originalCarModels = originalCar.Models.ToList();
			foreach (CarModel originalCarModel in originalCarModels)
			{
				DbEntityEntry<CarModel> entry = DbContext.Entry(originalCarModel);
				CarModel carModel = car.Models.SingleOrDefault(m => m.Id == originalCarModel.Id);
				// car model has been deleted
				if (carModel == null)
				{
					entry.State = EntityState.Deleted;
				}
				// car has been modified
				else
				{
					entry.CurrentValues.SetValues(carModel);
				}
			}
			foreach (CarModel carModel in car.Models)
			{
				// car has been added
				if (originalCarModels.SingleOrDefault(m => m.Id == carModel.Id) == null)
				{
					originalCar.Models.Add(carModel);
				}
			}
			DbEntityEntry<Car> originalCarEntry = DbContext.Entry(originalCar);
			originalCarEntry.CurrentValues.SetValues(car);
		}
	}
}
