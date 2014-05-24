using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICrudService<T> : IBaseService where T : BaseEntity
	{
		List<T> GetAll(int page, out int totalCount);

		T GetById(int id);

		void Create(T entity);

		void Update(T entity);

		bool Delete(int id);
	}
}
