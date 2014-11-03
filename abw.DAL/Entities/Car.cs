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

		public int Year { get; set; }

		[Required]
		[MaxLength(Constants.MaxStringLength)]
		public string Photo { get; set; }
	}
}
