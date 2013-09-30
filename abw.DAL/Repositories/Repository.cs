using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using abw.DAL.Contracts;

namespace abw.DAL.Repositories
{
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		private DbContext DbContext { get; set; }

		private DbSet<T> DbSet { get; set; }

		protected Repository(DbContext dbContext)
		{
			DbContext = dbContext;
			DbSet = DbContext.Set<T>();
		}

		public IEnumerable<T> GetAll()
		{
			return DbSet;
		}

		public T GetById(long id)
		{
			T entity = DbSet.Find(id);
			return entity;
		}

		public void Create(T entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			dbEntityEntry.State = EntityState.Added;
		}

		public void Update(T entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			dbEntityEntry.State = EntityState.Modified;
		}

		public bool Delete(long id)
		{
			T entity = GetById(id);
			if (entity == null)
			{
				return false;
			}
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			dbEntityEntry.State = EntityState.Deleted;
			return true;
		}
	}
}
