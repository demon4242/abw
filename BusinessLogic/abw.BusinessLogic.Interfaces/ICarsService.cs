using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICarsService : ICrudService<Car>
	{
		List<Car> GetAll();

		List<Car> GetByMakeAndModel(string make, string model);

		Car Get(string make, string model, int yearFrom, int? yearTo);

		bool CheckIfCarExists(Car car, Car originalCar = null);

		void Delete(Car car);
	}
}
