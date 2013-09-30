using System.Collections.Generic;

namespace abw.DAL.Contracts
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();

		T GetById(long id);

		void Create(T entity);

		void Update(T entity);

		bool Delete(long id);
	}
}
