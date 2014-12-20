using System.ComponentModel.DataAnnotations;
using abw.Common;
using abw.Resources;
using abw.ViewModels.ValidationAttributes;

namespace abw.ViewModels
{
	public class SignInModal
	{
		[Display(ResourceType = typeof(DisplayNames), Name = "Name")]
		[RequiredRestriction]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringMaxLength")]
		public string Name { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Password")]
		[RequiredRestriction]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringMaxLength")]
		public string Password { get; set; }
	}
}