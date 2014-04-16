using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICarService : ICrudService<Car>
	{
		bool CarMakeIsUnique(string make, int id);
	}
}
