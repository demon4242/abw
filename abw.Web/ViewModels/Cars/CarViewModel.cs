using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using abw.Common;
using abw.DAL.Entities;
using abw.Resources;
using abw.ValidationAttributes;

namespace abw.ViewModels
{
	public class CarViewModel : CarBase
	{
		[Display(ResourceType = typeof(DisplayNames), Name = "Make")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringMaxLength")]
		[Remote("CarMakeIsUnique", "Cars", AdditionalFields = "Id", ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "UniqueCarMake")]
		public override string Make { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Models")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[UniqueCarModels]
		public List<CarModelViewModel> Models { get; set; }

		public CarViewModel()
		{
			Models = new List<CarModelViewModel> { new CarModelViewModel() };
		}

		public CarMake ToEntity()
		{
			CarMake carMake = new CarMake();

			carMake.Id = Id;
			carMake.Name = Make;
			carMake.Cars = Models.ConvertAll(m => m.ToEntity(carMake.Id));

			return carMake;
		}
	}
}