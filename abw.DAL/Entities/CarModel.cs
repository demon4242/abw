using System.ComponentModel.DataAnnotations;
using abw.Common;

namespace abw.DAL.Entities
{
	public class CarModel : BaseEntity
	{
		[Required]
		[MaxLength(Constants.MaxStringLength)]
		public string Name { get; set; }

		[Required]
		public long CarId { get; set; }

		public Car Car { get; set; }
	}
}
