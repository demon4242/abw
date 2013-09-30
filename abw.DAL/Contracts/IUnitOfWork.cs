namespace abw.DAL.Contracts
{
	public interface IUnitOfWork
	{
		void Save();

		ICarsRepository Cars { get; }

		IMyCarsRepository MyCars { get; }
	}
}
