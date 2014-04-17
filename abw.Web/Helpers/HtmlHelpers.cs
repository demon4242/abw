using System.Web;
using System.Web.Mvc;

namespace abw.Helpers
{
	public static class HtmlHelpers
	{
		/// <summary>
		/// Converts model to js
		/// </summary>
		public static IHtmlString ToJs(this HtmlHelper htmlHelper, object model)
		{
			IHtmlString result = htmlHelper.Raw(NewtonJson.Serialize(model));
			return result;
		}
	}
}