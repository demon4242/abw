using System.ComponentModel.DataAnnotations;
using abw.Common;

namespace abw.DAL.Entities
{
	public class Car : BaseEntity
	{
		public int MakeId { get; set; }

		public virtual CarMake Make { get; set; }

		[Required]
		[MaxLength(Constants.MaxStringLength)]
		public string Model { get; set; }
	}
}
