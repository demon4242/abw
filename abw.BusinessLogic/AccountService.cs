using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.DAL.Repositories;

namespace abw.BusinessLogic
{
	public class AccountService : BaseService, IAccountService
	{
		public AccountService(UnitOfWork uow)
			: base(uow)
		{
		}

		public User GetUser(string name, string password)
		{
			string passwordHash = password.GetHashCode().ToString();
			User user = Uow.Users.All.SingleOrDefault(m => m.Name == name && m.Password == passwordHash);
			return user;
		}
	}
}
