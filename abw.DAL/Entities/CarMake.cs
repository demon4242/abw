using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using abw.Common;

namespace abw.DAL.Entities
{
	public class CarMake : BaseEntity
	{
		[Required]
		[MaxLength(Constants.MaxStringLength)]
		public string Name { get; set; }

		public virtual ICollection<Car> Cars { get; set; }
	}
}
