using abw.DAL.Entities;

namespace abw.DAL.Contracts
{
	public interface ICarsRepository : IRepository<Car>
	{
		Car Get(string make, string model, int yearFrom, int? yearTo);
	}
}
