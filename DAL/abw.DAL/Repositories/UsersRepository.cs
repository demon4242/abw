using System.Data.Entity;
using abw.Common;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.DAL.Repositories
{
	public class UsersRepository : Repository<User>, IUsersRepository
	{
		protected override string FileName => WebConfigManager.UsersFileName;
	}
}
