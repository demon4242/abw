using System;
using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICrudService<T> : IDisposable where T : BaseEntity
	{
		List<T> GetAll(out int totalCount);

		List<T> GetAll(int page);

		T GetById(int id);

		void Create(T entity);

		void Update(T entity);

		bool Delete(int id);
	}
}
