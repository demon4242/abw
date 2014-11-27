using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace abw.Web.Utilities.Helpers
{
	public static class HtmlHelpers
	{
		/// <summary>
		/// Converts model to js with camel case property names
		/// </summary>
		public static IHtmlString ToJs(this HtmlHelper htmlHelper, object model)
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			string json = JsonConvert.SerializeObject(model, jsonSerializerSettings);

			IHtmlString result = htmlHelper.Raw(json);
			return result;
		}
	}
}