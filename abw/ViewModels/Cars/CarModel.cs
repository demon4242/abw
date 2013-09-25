using System.ComponentModel.DataAnnotations;
using abw.Resources;

namespace abw.ViewModels
{
	public class CarModel
	{
		public long Id { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Model")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public string Name { get; set; }
	}
}