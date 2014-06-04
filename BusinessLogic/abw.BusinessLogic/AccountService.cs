using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.BusinessLogic
{
	public class AccountService : BaseService, IAccountService
	{
		public AccountService(IUnitOfWork uow)
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
