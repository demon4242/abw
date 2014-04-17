using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace abw.Helpers
{
	public static class CommonHelpers
	{
		/// <summary>
		/// Gets error messages from model state
		/// </summary>
		public static List<string> GetErrorMessages(ModelStateDictionary modelState)
		{
			List<string> errorMessages = new List<string>();
			modelState.Values.Select(m => m.Errors).ToList().ForEach(m => m.ToList()
				.ForEach(error => errorMessages.Add(error.ErrorMessage)));
			return errorMessages;
		}
	}
}