using System.Collections.Generic;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;

namespace abw.BusinessLogic
{
	public abstract class CrudService<T> : BaseService, ICrudService<T>
	{
		protected CrudService(IUnitOfWork uow)
			: base(uow)
		{
		}

		protected abstract IRepository<T> Repository { get; }

		public List<T> GetAll(int page, out int totalCount)
		{
			List<T> all = Repository.GetAll(page);
			totalCount = Repository.GetAll().Count;
			return all;
		}

		public void Create(T entity)
		{
			Repository.Create(entity);
		}

		public void Update(T entity, T originalEntity)
		{
			Repository.Update(entity, originalEntity);
		}
	}
}
