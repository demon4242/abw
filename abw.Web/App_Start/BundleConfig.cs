using System.Web.Optimization;

namespace abw.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			#region Styles

			const string stylesDirectory = "~/Content/styles/";

			// global styles
			Bundle globalStyles = new Bundle("~/globalStyles")
				.IncludeDirectory(stylesDirectory + "bootstrap-3.0.3", "*.css")
				.Include(stylesDirectory + "custom/global.less")
				.Include(stylesDirectory + "bootstrap-notify-1.0.css");
			AddStyleBundle(ref bundles, globalStyles);

			// car styles
			Bundle carStyles = new Bundle("~/car")
				.Include(stylesDirectory + "custom/car.less");
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