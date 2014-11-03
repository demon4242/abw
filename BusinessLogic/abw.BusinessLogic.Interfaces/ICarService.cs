using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICarService : ICrudService<Car>
	{
		List<Car> GetAll();
	}
}
