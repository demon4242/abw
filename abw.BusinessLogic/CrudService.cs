using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;
using abw.DAL.Repositories;

namespace abw.BusinessLogic
{
	public abstract class CrudService<T> : ICrudService<T> where T : BaseEntity
	{
		protected readonly UnitOfWork Uow;

		protected CrudService(UnitOfWork uow)
		{
			Uow = uow;
		}

		protected abstract IRepository<T> Repository { get; }

		public List<T> GetAll(int? page)
		{
			List<T> all = Repository.GetAll(page).ToList();
			return all;
		}

		public T GetById(long id)
		{
			T entity = Repository.GetById(id);
			return entity;
		}

		public void Create(T car)
		{
			Repository.Create(car);
			Save();
		}

		public void Update(T car)
		{
			Repository.Update(car);
			Save();
		}

		public bool Delete(long id)
		{
			bool success = Repository.Delete(id);
			if (success)
			{
				Save();
			}
			return success;
		}

		public void Dispose()
		{
			Uow.Dispose();
		}

		private void Save()
		{
			Uow.Save();
		}
	}
}
