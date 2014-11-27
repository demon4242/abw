using System.ComponentModel.DataAnnotations;

namespace abw.DAL.Entities
{
	public class User : BaseEntity
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
