using System.Collections.Generic;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICrudService<T> : IBaseService
	{
		List<T> GetAll(int page, out int totalCount);

		void Create(T entity);

		void Update(T entity, T originalEntity);
	}
}
