using System.ComponentModel.DataAnnotations;

namespace abw.DAL.Entities
{
	public class MyCar : BaseEntity
	{
		[Required]
		public int CarId { get; set; }

		public Car Car { get; set; }

		[Required]
		public int Year { get; set; }
	}
}
