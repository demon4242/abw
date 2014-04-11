using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using abw.Common;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.DAL.Repositories
{
	public abstract class Repository<T> : IRepository<T> where T : BaseEntity
	{
		private DbContext DbContext { get; set; }

		private DbSet<T> DbSet { get; set; }

		protected Repository(DbContext dbContext)
		{
			DbContext = dbContext;
			DbSet = DbContext.Set<T>();
		}

		public IQueryable<T> GetAll(int? page)
		{
			if (!page.HasValue)
			{
				page = 1;
			}
			IQueryable<T> entities = DbSet
				.OrderBy(m => m.Id)
				.Skip((page.Value - 1) * WebConfigManager.GridPageSize)
				.Take(WebConfigManager.GridPageSize);
			return entities;
		}

		public T GetById(int id)
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

		public bool Delete(int id)
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
