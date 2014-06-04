using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICarService : ICrudService<CarMake>
	{
		bool CarMakeIsUnique(string make, int id);
	}
}
