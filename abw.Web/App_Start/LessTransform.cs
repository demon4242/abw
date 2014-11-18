using System.Web.Optimization;
using dotless.Core;

namespace abw.App_Start
{
	public class LessTransform : IBundleTransform
	{
		public void Process(BundleContext context, BundleResponse response)
		{
			response.Content = Less.Parse(response.Content);
			response.ContentType = "text/css";
		}
	}
}