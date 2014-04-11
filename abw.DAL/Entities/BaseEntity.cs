using System.ComponentModel.DataAnnotations;

namespace abw.DAL.Entities
{
	public abstract class BaseEntity
	{
		[Required]
		public int Id { get; set; }
	}
}
