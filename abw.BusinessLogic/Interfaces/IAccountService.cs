using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface IAccountService : IBaseService
	{
		User GetUser(string name, string password);
	}
}
