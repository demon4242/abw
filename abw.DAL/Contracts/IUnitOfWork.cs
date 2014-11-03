using System;

namespace abw.DAL.Contracts
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();

		ICarsRepository Cars { get; }

		IUsersRepository Users { get; }
	}
}
