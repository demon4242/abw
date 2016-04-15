namespace abw.ViewModels
{
	public class CarForGrid
	{
		public virtual string Make { get; set; }

		public virtual string Model { get; set; }

		public virtual int YearFrom { get; set; }

		public virtual int? YearTo { get; set; }
	}
}