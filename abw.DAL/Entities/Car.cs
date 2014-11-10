using System.ComponentModel.DataAnnotations;
using abw.Common;

namespace abw.DAL.Entities
{
	public class Car : BaseEntity
	{
		[Required]
		[MaxLength(Constants.MaxStringLength)]
		public string Make { get; set; }

		[Required]
		[MaxLength(Constants.MaxStringLength)]
		public string Model { get; set; }

		public int YearFrom { get; set; }

		public int? YearTo { get; set; }
	}
}
