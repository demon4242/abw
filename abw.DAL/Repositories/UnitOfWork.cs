using System;
using abw.DAL.Contracts;

namespace abw.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public void Save()
		{
			throw new NotImplementedException();
		}

		public ICarsRepository Cars
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IMyCarsRepository MyCars
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
