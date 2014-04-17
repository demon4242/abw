using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using abw.Resources;
using abw.ViewModels;

namespace abw.ValidationAttributes
{
	// todo: add client validation
	public class UniqueCarModelsAttribute : ValidationAttribute
	{
		public UniqueCarModelsAttribute()
		{
			ErrorMessageResourceType = typeof(ErrorMessages);
			ErrorMessageResourceName = "UniqueCarModels";
		}

		public override bool IsValid(object value)
		{
			List<string> carModels = ((List<CarModelViewModel>)value)
				.Select(m => m.Name.Trim().ToLower())
				.ToList();

			bool isValid = carModels.Count == carModels.Distinct().Count();
			return isValid;
		}
	}
}