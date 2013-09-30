using System.Data.Entity;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.DAL.Repositories
{
	public class MyCarsRepository : Repository<MyCar>, IMyCarsRepository
	{
		public MyCarsRepository(DbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
