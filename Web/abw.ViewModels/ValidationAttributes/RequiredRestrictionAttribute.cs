using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using abw.Resources;

namespace abw.ViewModels.ValidationAttributes
{
	public class RequiredRestrictionAttribute : RequiredAttribute, IClientValidatable
	{
		public RequiredRestrictionAttribute()
		{
			ErrorMessageResourceType = typeof(ErrorMessages);
			ErrorMessageResourceName = "Required";
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			ModelClientValidationRule rule = new ModelClientValidationRule
			{
				ValidationType = "required",
				ErrorMessage = FormatErrorMessage(metadata.DisplayName)
			};
			yield return rule;
		}
	}
}
