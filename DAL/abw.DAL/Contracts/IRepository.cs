using System.Collections.Generic;

namespace abw.DAL.Contracts
{
	public interface IRepository<T>
	{
		List<T> GetAll();

		List<T> GetAll(int page);

		void Create(T entity);

		void Update(T entity, T originalEntity);

		void Delete(T entity);
	}
}
