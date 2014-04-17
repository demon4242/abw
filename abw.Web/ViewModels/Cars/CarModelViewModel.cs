using System.ComponentModel.DataAnnotations;
using abw.Common;
using abw.DAL.Entities;
using abw.Resources;

namespace abw.ViewModels
{
	public class CarModelViewModel
	{
		public int Id { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Model")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringMaxLength")]
		public string Name { get; set; }

		public CarModel ToEntity(int carId)
		{
			CarModel carModel = new CarModel();

			carModel.Id = Id;
			carModel.Name = Name;
			carModel.CarId = carId;

			return carModel;
		}
	}
}