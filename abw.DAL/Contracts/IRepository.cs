using System.Collections.Generic;
using System.Linq;
using abw.DAL.Entities;

namespace abw.DAL.Contracts
{
	public interface IRepository<T> where T : BaseEntity
	{
		IQueryable<T> All { get; }

		List<T> GetAll(int page = 1);

		T GetById(int id);

		void Create(T entity);

		void Update(T carMake);

		bool Delete(int id);
	}
}
