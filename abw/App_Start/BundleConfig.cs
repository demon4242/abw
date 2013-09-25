using System.Web.Optimization;

namespace abw.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			// global scripts
			Bundle scriptBundle = new Bundle("~/globalScripts")
				.Include("~/Scripts/bootstrap.js")
				.Include("~/Scripts/jquery-{version}.js");
			bundles.Add(scriptBundle);

			// global styles
			Bundle styleBundle = new Bundle("~/globalStyles")
				.IncludeDirectory("~/Content/bootstrap", "*.css")
				.Include("~/Content/global.less");
			styleBundle.Transforms.Add(new LessTransform());
			styleBundle.Transforms.Add(new CssMinify());
			bundles.Add(styleBundle);

			// validation
			Bundle validation = new Bundle("~/validation")
				.Include("~/Scripts/validation/jquery.validate.js")
				.Include("~/Scripts/validation/jquery.validate.unobtrusive.js");
			bundles.Add(validation);
		}
	}
}