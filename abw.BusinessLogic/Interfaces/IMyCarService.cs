using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface IMyCarService : ICrudService<MyCar>
	{
		List<CarMake> GetAllCarMakes();

		List<Car> GetCarModelsByMake(int makeId);
	}
}
