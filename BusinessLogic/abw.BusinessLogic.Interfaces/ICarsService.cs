using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICarsService : ICrudService<Car>
	{
		List<Car> GetAll();

		List<Car> GetByMake(string make);

		bool CheckIfCarExists(Car car, Car originalCar = null);
	}
}
