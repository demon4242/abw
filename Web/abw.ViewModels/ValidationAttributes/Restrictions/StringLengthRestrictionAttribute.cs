using System.ComponentModel.DataAnnotations;
using abw.Resources;

namespace abw.ViewModels.ValidationAttributes
{
	public class StringLengthRestrictionAttribute : StringLengthAttribute
	{
		public StringLengthRestrictionAttribute(int maximumLength)
			: base(maximumLength)
		{
			ErrorMessageResourceType = typeof(ErrorMessages);
			ErrorMessageResourceName = "StringMaxLength";
		}
	}
}
