using System;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.DAL.Repositories;

namespace abw.BusinessLogic
{
	// todo: implement base service
	public class AccountService : IAccountService, IDisposable
	{
		private readonly UnitOfWork _uow;

		public AccountService(UnitOfWork uow)
		{
			_uow = uow;
		}

		public User GetUser(string name, string password)
		{
			string passwordHash = password.GetHashCode().ToString();
			User user = _uow.Users.All.SingleOrDefault(m => m.Name == name && m.Password == passwordHash);
			return user;
		}

		public void Dispose()
		{
			_uow.Dispose();
		}
	}
}
