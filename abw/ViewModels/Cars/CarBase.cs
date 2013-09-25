namespace abw.ViewModels
{
	public abstract class CarBase
	{
		public long Id { get; set; }

		public virtual string Make { get; set; }
	}
}