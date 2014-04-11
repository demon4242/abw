using System.ComponentModel.DataAnnotations;

namespace abw.DAL.Entities
{
	public class MyCar : BaseEntity
	{
		[Required]
		public int CarModelId { get; set; }

		public CarModel CarModel { get; set; }

		[Required]
		public int Year { get; set; }
	}
}
