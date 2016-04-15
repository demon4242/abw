namespace abw.DAL.Contracts
{
	public interface IUnitOfWork
	{
		ICarsRepository Cars { get; }

		IUsersRepository Users { get; }
	}
}
