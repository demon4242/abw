using abw.DAL.Contracts;

namespace abw.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		#region Private

		private readonly AbwDbContext _dbContext = new AbwDbContext();

		private ICarMakesRepository _carMakes;

		private IMyCarsRepository _myCars;

		#endregion Private

		#region Public

		public ICarMakesRepository CarMakes
		{
			get
			{
				ICarMakesRepository carMakes = _carMakes ?? (_carMakes = new CarMakesRepository(_dbContext));
				return carMakes;
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
