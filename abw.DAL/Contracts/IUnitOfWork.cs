using System;

namespace abw.DAL.Contracts
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();

		ICarMakesRepository CarMakes { get; }

		IMyCarsRepository MyCars { get; }
	}
}
