namespace abw.DAL.Entities
{
	public class MyCar : BaseEntity
	{
		public CarModel CarModel { get; set; }

		public int Year { get; set; }
	}
}
