using System.ComponentModel.DataAnnotations;

namespace abw.DAL.Entities
{
	public class MyCar : BaseEntity
	{
		public int CarId { get; set; }

		public virtual Car Car { get; set; }

		public int Year { get; set; }

		[Required]
		public string Photo { get; set; }
	}
}
