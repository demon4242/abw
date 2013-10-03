using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using abw.Common;

namespace abw.DAL.Entities
{
	public class Car : BaseEntity
	{
		[Required]
		[MaxLength(Constants.MaxStringLength)]
		public string Make { get; set; }

		public virtual ICollection<CarModel> Models { get; set; }
	}
}
