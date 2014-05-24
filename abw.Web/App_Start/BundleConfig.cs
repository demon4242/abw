using System.Web.Optimization;

namespace abw.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			const string stylesDirectory = "~/Content/styles/";
			string customStylesDirectory = string.Format("{0}custom/", stylesDirectory);

			Bundle globalStyles = new Bundle("~/global")
				.IncludeDirectory(stylesDirectory + "bootstrap-3.1.1", "*.css")
				.Include(customStylesDirectory + "global.less")
				.Include(customStylesDirectory + "notifications.less")
				.Include(customStylesDirectory + "spinner.less");
			AddStyleBundle(ref bundles, globalStyles);

			Bundle carStyles = new Bundle("~/car")
				.Include(customStylesDirectory + "car.less");
			AddStyleBundle(ref bundles, carStyles);

			Bundle gridStyles = new Bundle("~/grid")
				.Include(customStylesDirectory + "grid.less");
			AddStyleBundle(ref bundles, gridStyles);

			Bundle contactsStyles = new Bundle("~/contacts")
				.Include(customStylesDirectory + "contacts.less");
			AddStyleBundle(ref bundles, contactsStyles);

			Bundle formsStyles = new Bundle("~/forms")
				.Include(customStylesDirectory + "forms.less");
			AddStyleBundle(ref bundles, formsStyles);
		}

		private static void AddStyleBundle(ref BundleCollection bundles, Bundle styleBundle)
		{
			styleBundle.Transforms.Add(new LessTransform());
			styleBundle.Transforms.Add(new CssMinify());
			bundles.Add(styleBundle);
		}
	}
}