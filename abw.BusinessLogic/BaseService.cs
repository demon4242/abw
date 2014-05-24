using abw.BusinessLogic.Interfaces;
using abw.DAL.Repositories;

namespace abw.BusinessLogic
{
	public abstract class BaseService : IBaseService
	{
		protected readonly UnitOfWork Uow;

		protected BaseService(UnitOfWork uow)
		{
			Uow = uow;
		}

		public void Dispose()
		{
			Uow.Dispose();
		}
	}
}
