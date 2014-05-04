using System.Data.Entity;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.DAL.Repositories
{
	public class UsersRepository : Repository<User>, IUsersRepository
	{
		public UsersRepository(DbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
