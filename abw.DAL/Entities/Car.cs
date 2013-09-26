using System.Collections.Generic;

namespace abw.DAL.Entities
{
	public class Car : BaseEntity
	{
		public string Make { get; set; }

		public virtual ICollection<CarModel> Models { get; set; }
	}
}
