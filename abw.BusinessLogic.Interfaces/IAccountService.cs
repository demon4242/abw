using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface IAccountService
	{
		User GetUser(string name, string password);
	}
}
