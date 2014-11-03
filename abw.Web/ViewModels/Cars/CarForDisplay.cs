namespace abw.ViewModels
{
	public class CarForDisplay
	{
		public int Id { get; set; }

		public virtual string Make { get; set; }

		public virtual string Model { get; set; }

		public virtual int Year { get; set; }
	}
}