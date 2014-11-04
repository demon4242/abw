using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using abw.DAL.Entities;
using abw.ViewModels;

namespace abw.Helpers
{
	public static class PhotoManager
	{
		private const string Folder = "photos";

		private static readonly HttpServerUtility Server = HttpContext.Current.Server;

		public static void Save(CarViewModel car)
		{
			if (car.Photos[0] == null)
			{
				return;
			}

			string path = Server.MapPath(string.Format("~/{0}/{1} {2} {3}", Folder, car.Make, car.Model, car.Year));
			bool exists = Directory.Exists(path);
			if (!exists)
			{
				Directory.CreateDirectory(path);
			}

			foreach (HttpPostedFileBase photo in car.Photos)
			{
				string fileName = string.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(photo.FileName));
				photo.SaveAs(string.Format("{0}/{1}", path, fileName));
			}
		}

		public static List<string> Get(Car car)
		{
			string path = GetPath(car);
			bool exists = Directory.Exists(path);
			if (!exists)
			{
				return new List<string>();
			}

			string[] files = Directory.GetFiles(path);
			// convert to relative path
			for (int i = 0; i < files.Length; i++)
			{
				files[i] = "~" + files[i].Replace(Server.MapPath("~"), string.Empty);
			}
			return files.ToList();
		}

		public static void Delete(Car car)
		{
			string path = GetPath(car);
			bool exists = Directory.Exists(path);
			if (exists)
			{
				Directory.Delete(path, true);
			}
		}

		private static string GetPath(Car car)
		{
			string path = Server.MapPath(string.Format("~/{0}/{1} {2} {3}", Folder, car.Make, car.Model, car.Year));
			return path;
		}
	}
}