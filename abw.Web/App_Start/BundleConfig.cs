using System.Web.Optimization;
using BundleTransformer.Core.Bundles;

namespace abw.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			const string stylesDirectory = "~/Content/styles/";
			string customStylesDirectory = $"{stylesDirectory}custom/";

			Bundle bootstrapStyles = new CustomStyleBundle(stylesDirectory + "bootstrap/css")
				.IncludeDirectory(stylesDirectory + "bootstrap", "*.css");
			AddBundle(ref bundles, bootstrapStyles);

			Bundle fotoramaStyles = new CustomStyleBundle(stylesDirectory + "fotorama")
				.Include(stylesDirectory + "fotorama.css");
			AddBundle(ref bundles, fotoramaStyles);

			Bundle globalStyles = new CustomStyleBundle(customStylesDirectory + "global")
				.Include(customStylesDirectory + "global.less")
				.Include(customStylesDirectory + "carousel.less")
				.Include(customStylesDirectory + "notifications.less")
				.Include(customStylesDirectory + "spinner.less")
				.Include(customStylesDirectory + "forms.less");
			globalStyles.Transforms.Add(new CssMinify());
			AddBundle(ref bundles, globalStyles);

			Bundle carStyles = new CustomStyleBundle(customStylesDirectory + "car")
				.Include(customStylesDirectory + "car.less");
			AddBundle(ref bundles, carStyles);

			Bundle gridStyles = new CustomStyleBundle(customStylesDirectory + "grid")
				.Include(customStylesDirectory + "grid.less");
			AddBundle(ref bundles, gridStyles);

			Bundle contactsStyles = new CustomStyleBundle(customStylesDirectory + "contacts")
				.Include(customStylesDirectory + "contacts.less");
			AddBundle(ref bundles, contactsStyles);
		}

		private static void AddBundle(ref BundleCollection bundles, Bundle bundle)
		{
			bundle.Transforms.Add(new CssMinify());
			bundles.Add(bundle);
		}
	}
}