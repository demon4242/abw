using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using abw.DAL.Entities;
using abw.Logging;
using abw.ViewModels;

namespace abw.Helpers
{
	public static class PhotoManager
	{
		private const string Folder = "photos";

		private static readonly HttpServerUtility Server = HttpContext.Current.Server;

		#region Public methods

		public static void Save(CarViewModel car)
		{
			if (car.Photos[0] == null)
			{
				return;
			}

			string path = GetPath(car);
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

		public static void Update(string originalName, CarViewModel car)
		{
			string newName = GetCarName(car);
			string newPath = GetPath(newName);

			if (originalName.ToLower() != newName.ToLower())
			{
				bool newFolderExists = Directory.Exists(newPath);
				if (!newFolderExists)
				{
					string originalPath = GetPath(originalName);
					bool originalFolderExists = Directory.Exists(originalPath);
					if (originalFolderExists)
					{
						Directory.Move(originalPath, newPath);
					}
				}
			}

			foreach (KeyValuePair<string, bool> currentPhoto in car.CurrentPhotos)
			{
				// if current photo is NOT marked as 'must be deleted'
				if (!currentPhoto.Value)
				{
					continue;
				}

				string fileName = Path.GetFileName(currentPhoto.Key);
				if (fileName == null)
				{
					const string errorMessage = "Current photo file name cannot be null";
					Logger.Error(errorMessage);
					throw new Exception(errorMessage);
				}
				string filePath = Path.Combine(newPath, fileName);
				File.Delete(filePath);
			}

			Save(car);
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

		public static string GetCarName(Car car)
		{
			string carName = string.Format("{0} {1} {2}-{3}", car.Make, car.Model, car.YearFrom, car.YearTo);
			return carName;
		}

		#endregion Public methods

		#region Private methods

		private static string GetCarName(CarViewModel car)
		{
			string carName = string.Format("{0} {1} {2}-{3}", car.Make.Trim(), car.Model.Trim(), car.YearFrom, car.YearTo);
			return carName;
		}

		private static string GetPath(string carName)
		{
			string path = Server.MapPath(string.Format("~/{0}/{1}", Folder, carName));
			return path;
		}

		private static string GetPath(Car car)
		{
			string carName = GetCarName(car);
			string path = GetPath(carName);
			return path;
		}

		private static string GetPath(CarViewModel car)
		{
			string carName = GetCarName(car);
			string path = GetPath(carName);
			return path;
		}

		#endregion Private methods
	}
}