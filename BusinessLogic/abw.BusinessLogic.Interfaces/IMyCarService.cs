using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface IMyCarService : ICrudService<MyCar>
	{
		new int Create(MyCar myCar);

		List<CarMake> GetAllCarMakes();

		List<Car> GetCarModelsByMake(int makeId);
	}
}
