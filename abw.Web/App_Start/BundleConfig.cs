using System.Web.Optimization;
using BundleTransformer.Core.Bundles;

namespace abw.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			const string stylesDirectory = "~/Content/styles/";
			string customStylesDirectory = string.Format("{0}custom/", stylesDirectory);

			Bundle bootstrapStyles = new CustomStyleBundle(stylesDirectory + "bootstrap-3.1.1/css")
				.IncludeDirectory(stylesDirectory + "bootstrap-3.1.1", "*.css");
			bundles.Add(bootstrapStyles);

			Bundle globalStyles = new CustomStyleBundle(customStylesDirectory + "global")
				.Include(customStylesDirectory + "global.less")
				.Include(customStylesDirectory + "notifications.less")
				.Include(customStylesDirectory + "spinner.less")
				.Include(customStylesDirectory + "forms.less");
			bundles.Add(globalStyles);

			Bundle carStyles = new CustomStyleBundle(customStylesDirectory + "car")
				.Include(customStylesDirectory + "car.less");
			bundles.Add(carStyles);

			Bundle gridStyles = new CustomStyleBundle(customStylesDirectory + "grid")
				.Include(customStylesDirectory + "grid.less");
			bundles.Add(gridStyles);

			Bundle carsStyles = new CustomStyleBundle(customStylesDirectory + "cars")
				.Include(customStylesDirectory + "cars.less");
			bundles.Add(carsStyles);

			Bundle contactsStyles = new CustomStyleBundle(customStylesDirectory + "contacts")
				.Include(customStylesDirectory + "contacts.less");
			bundles.Add(contactsStyles);
		}
	}
}