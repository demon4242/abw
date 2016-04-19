using abw.DAL.Contracts;

namespace abw.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private ICarsRepository _cars;

		private IUsersRepository _users;

		public ICarsRepository Cars
		{
			get
			{
				ICarsRepository cars = _cars ?? (_cars = new CarsRepository());
				return cars;
			}
		}

		public IUsersRepository Users
		{
			get
			{
				IUsersRepository users = _users ?? (_users = new UsersRepository());
				return users;
			}
		}
	}
}
