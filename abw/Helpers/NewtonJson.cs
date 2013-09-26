using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace abw.Helpers
{
	public class NewtonJson
	{
		/// <summary>
		/// Serializes object with camel case property names
		/// </summary>
		public static string Serialize(object model)
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			string json = JsonConvert.SerializeObject(model, jsonSerializerSettings);
			return json;
		}
	}
}