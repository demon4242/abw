namespace abw.ViewModels
{
	public class CarForFullDisplay : CarForDisplay
	{
		public string Make { get; set; }

		public string Model { get; set; }

		public int YearFrom { get; set; }

		public int? YearTo { get; set; }
	}
}