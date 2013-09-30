using System.ComponentModel.DataAnnotations;

namespace abw.DAL.Entities
{
	public abstract class BaseEntity
	{
		[Required]
		public long Id { get; set; }
	}
}
