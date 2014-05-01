using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace abw.Helpers
{
	/// <summary>
	/// Makes json lower case
	/// </summary>
	public class JsonNetResult : ActionResult
	{
		private readonly object _data;

		public JsonNetResult(object data)
		{
			_data = data;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			HttpResponseBase response = context.HttpContext.Response;
			response.ContentType = "application/json";

			JsonTextWriter writer = new JsonTextWriter(response.Output);
			JsonSerializerSettings serializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			JsonSerializer serializer = JsonSerializer.Create(serializerSettings);
			serializer.Serialize(writer, _data);
			writer.Flush();
		}
	}
}