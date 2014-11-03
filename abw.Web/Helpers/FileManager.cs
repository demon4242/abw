using System.IO;
using System.Web;

namespace abw.Helpers
{
	public static class FileManager
	{
		private const string PhotosDirectory = "photos";

		public static void SaveCarPhoto(HttpPostedFileBase photo, int carId, HttpServerUtilityBase server)
		{
			string photoDirectory = server.MapPath(string.Format("~/{0}/{1}", PhotosDirectory, carId));
			bool exists = Directory.Exists(photoDirectory);
			if (!exists)
			{
				Directory.CreateDirectory(photoDirectory);
			}

			photo.SaveAs(string.Format("{0}/{1}", photoDirectory, photo.FileName));
		}
	}
}