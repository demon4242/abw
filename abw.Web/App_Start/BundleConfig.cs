using System.Web.Optimization;

namespace abw.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			const string stylesDirectory = "~/Content/styles/";
			string customStylesDirectory = string.Format("{0}custom/", stylesDirectory);

			Bundle bootstrapStyles = new Bundle(stylesDirectory + "bootstrap-3.1.1/css")
				.IncludeDirectory(stylesDirectory + "bootstrap-3.1.1", "*.css");
			AddStyleBundle(ref bundles, bootstrapStyles, false);

			Bundle globalStyles = new Bundle(customStylesDirectory + "global")
				.Include(customStylesDirectory + "global.less")
				.Include(customStylesDirectory + "notifications.less")
				.Include(customStylesDirectory + "spinner.less");
			AddStyleBundle(ref bundles, globalStyles);

			Bundle carStyles = new Bundle(customStylesDirectory + "car")
				.Include(customStylesDirectory + "car.less");
			AddStyleBundle(ref bundles, carStyles);

			Bundle gridStyles = new Bundle(customStylesDirectory + "grid")
				.Include(customStylesDirectory + "grid.less");
			AddStyleBundle(ref bundles, gridStyles);

			Bundle carsStyles = new Bundle(customStylesDirectory + "cars")
				.Include(customStylesDirectory + "cars.less");
			AddStyleBundle(ref bundles, carsStyles);

			Bundle contactsStyles = new Bundle(customStylesDirectory + "contacts")
				.Include(customStylesDirectory + "contacts.less");
			AddStyleBundle(ref bundles, contactsStyles);

			Bundle formsStyles = new Bundle(customStylesDirectory + "forms")
				.Include(customStylesDirectory + "forms.less");
			AddStyleBundle(ref bundles, formsStyles);
		}

		private static void AddStyleBundle(ref BundleCollection bundles, Bundle bundle, bool isLess = true)
		{
			if (isLess)
			{
				bundle.Transforms.Add(new LessTransform());
			}
			bundle.Transforms.Add(new CssMinify());
			bundles.Add(bundle);
		}
	}
}