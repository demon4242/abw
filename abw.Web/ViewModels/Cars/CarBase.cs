namespace abw.ViewModels
{
	public abstract class CarBase
	{
		public virtual string Make { get; set; }

		public virtual string Model { get; set; }

		public virtual int Year { get; set; }
	}
}