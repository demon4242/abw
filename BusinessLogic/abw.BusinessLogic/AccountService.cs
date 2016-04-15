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
			User user = Uow.Users.GetAll().SingleOrDefault(m => m.Name == name && m.Password == password);
			return user;
		}
	}
}
