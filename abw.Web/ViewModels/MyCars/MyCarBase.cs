namespace abw.ViewModels.MyCars
{
	public abstract class MyCarBase
	{
		public long Id { get; set; }

		public virtual int Year { get; set; }
	}
}