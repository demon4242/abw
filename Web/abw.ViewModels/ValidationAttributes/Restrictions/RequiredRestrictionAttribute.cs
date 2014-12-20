using System.ComponentModel.DataAnnotations;
using abw.Resources;

namespace abw.ViewModels.ValidationAttributes
{
	public class RequiredRestrictionAttribute : RequiredAttribute
	{
		public RequiredRestrictionAttribute()
		{
			ErrorMessageResourceType = typeof(ErrorMessages);
			ErrorMessageResourceName = "Required";
		}
	}
}
