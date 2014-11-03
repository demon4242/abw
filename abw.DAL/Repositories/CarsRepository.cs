using System.Data.Entity;
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
	}
}
