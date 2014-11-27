using System.ComponentModel.DataAnnotations;
using abw.Common;
using abw.Resources;

namespace abw.ViewModels
{
	public class SignInModal
	{
		[Display(ResourceType = typeof(DisplayNames), Name = "Name")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringMaxLength")]
		public string Name { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Password")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringMaxLength")]
		public string Password { get; set; }
	}
}