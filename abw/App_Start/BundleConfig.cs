using System.Web.Optimization;

namespace abw.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			// scripts
			Bundle scriptBundle = new Bundle("~/global")
				.Include("~/Scripts/bootstrap.js")
				.Include("~/Scripts/jquery-{version}.js");
			bundles.Add(scriptBundle);

			// styles
			Bundle styleBundle = new Bundle("~/global")
				.IncludeDirectory("~/Content/bootstrap", "*.css")
				.Include("~/Content/global.less");
			styleBundle.Transforms.Add(new LessTransform());
			styleBundle.Transforms.Add(new CssMinify());
			bundles.Add(styleBundle);
		}
	}
}