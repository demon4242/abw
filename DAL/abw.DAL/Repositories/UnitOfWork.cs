using abw.DAL.Contracts;

namespace abw.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AbwDbContext _dbContext;

		private ICarsRepository _cars;
		private IUsersRepository _users;

		public UnitOfWork(AbwDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ICarsRepository Cars
		{
			get
			{
				ICarsRepository cars = _cars ?? (_cars = new CarsRepository(_dbContext));
				return cars;
			}
		}

		public IUsersRepository Users
		{
			get
			{
				IUsersRepository users = _users ?? (_users = new UsersRepository(_dbContext));
				return users;
			}
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
