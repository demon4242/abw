using abw.DAL.Contracts;

namespace abw.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		#region Private

		private readonly AbwDbContext _dbContext = new AbwDbContext();

		private ICarsRepository _cars;

		private IMyCarsRepository _myCars;

		#endregion Private

		#region Public

		public ICarsRepository Cars
		{
			get
			{
				ICarsRepository cars = _cars ?? (_cars = new CarsRepository(_dbContext));
				return cars;
			}
		}

		public IMyCarsRepository MyCars
		{
			get
			{
				IMyCarsRepository myCars = _myCars ?? (_myCars = new MyCarsRepository(_dbContext));
				return myCars;
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

		#endregion Public
	}
}
