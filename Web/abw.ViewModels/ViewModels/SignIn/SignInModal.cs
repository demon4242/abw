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
		[StringLengthRestriction(Constants.MaxStringLength)]
		public string Name { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Password")]
		[RequiredRestriction]
		[StringLengthRestriction(Constants.MaxStringLength)]
		public string Password { get; set; }
	}
}