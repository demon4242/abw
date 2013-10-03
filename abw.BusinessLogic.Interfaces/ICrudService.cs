using System;
using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface ICrudService<T> : IDisposable where T : BaseEntity
	{
		List<T> GetAll(int? page);

		T GetById(long id);

		void Create(T car);

		void Update(T car);

		bool Delete(long id);
	}
}
