using abw.DAL.Contracts;

namespace abw.BusinessLogic
{
	public abstract class BaseService
	{
		protected readonly IUnitOfWork Uow;

		protected BaseService(IUnitOfWork uow)
		{
			Uow = uow;
		}
	}
}
