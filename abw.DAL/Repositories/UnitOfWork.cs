﻿using abw.DAL.Contracts;

namespace abw.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		#region Private

		private readonly AbwDbContext _dbContext = new AbwDbContext();

		private ICarsRepository _cars;

		private IUsersRepository _users;

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

		#endregion Public
	}
}
