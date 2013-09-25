using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using abw.Resources;

namespace abw.ViewModels
{
	public class Car : CarBase
	{
		[Display(ResourceType = typeof(DisplayNames), Name = "Make")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public override string Make { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Models")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public List<CarModel> Models { get; set; }

		public Car()
		{
			Models = new List<CarModel> { new CarModel() };
		}
	}
}