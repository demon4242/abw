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

		// todo: get repository using reflection
		protected abstract IRepository<T> Repository { get; }

		public List<T> GetAll(int page, out int totalCount)
		{
			List<T> all = Repository.GetAll(page);
			totalCount = Repository.All.Count();
			return all;
		}

		public T GetById(int id)
		{
			T entity = Repository.GetById(id);
			return entity;
		}

		public void Create(T entity)
		{
			Repository.Create(entity);
			Save();
		}

		public void Update(T entity)
		{
			Repository.Update(entity);
			Save();
		}

		public bool Delete(int id)
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
