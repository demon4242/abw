using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;

namespace abw.BusinessLogic
{
	public abstract class BaseService : IBaseService
	{
		protected readonly IUnitOfWork Uow;

		protected BaseService(IUnitOfWork uow)
		{
			Uow = uow;
		}

		public void Dispose()
		{
			Uow.Dispose();
		}
	}
}
