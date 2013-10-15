using System.Web.Optimization;

namespace abw.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			#region Scripts

			// global scripts
			Bundle globalScripts = new Bundle("~/globalScripts")
				.Include("~/Scripts/bootstrap.js")
				.Include("~/Scripts/jquery-{version}.js");
			bundles.Add(globalScripts);

			// validation
			Bundle validation = new Bundle("~/validation")
				.Include("~/Scripts/validation/jquery.validate.js")
				.Include("~/Scripts/validation/jquery.validate.unobtrusive.js");
			bundles.Add(validation);

			// knockout
			Bundle knockout = new Bundle("~/knockout")
				.IncludeDirectory("~/Scripts/knockout", "*.js");
			bundles.Add(knockout);

			#endregion Scripts

			#region Styles

			// global styles
			Bundle globalStyles = new Bundle("~/globalStyles")
				.IncludeDirectory("~/Content/bootstrap", "*.css")
				.Include("~/Content/font-awesome.css")
				.Include("~/Content/global.less");
			AddStyleBundle(ref bundles, globalStyles);

			// car styles
			Bundle carStyles = new Bundle("~/car")
				.Include("~/Content/car.less");
			AddStyleBundle(ref bundles, carStyles);

			#endregion Styles
		}

		private static void AddStyleBundle(ref BundleCollection bundles, Bundle styleBundle)
		{
			styleBundle.Transforms.Add(new LessTransform());
			styleBundle.Transforms.Add(new CssMinify());
			bundles.Add(styleBundle);
		}
	}
}