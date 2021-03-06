﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using abw.DAL.Entities;
using abw.Logging;
using abw.ViewModels;

namespace abw.Web.Utilities.Helpers
{
	public static class PhotoManager
	{
		private const string Folder = "photos";
		private const string CarNamePattern = "{0}_{1}_{2}-{3}";

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
				string fileName = $"{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";
				photo.SaveAs($"{path}/{fileName}");
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

			string appPath = Server.MapPath("~");
			// get rid of two back slashes in the end if they are
			appPath = Regex.Replace(appPath, @"\\$", string.Empty);

			string[] files = Directory.GetFiles(path);
			// convert to relative path
			for (int i = 0; i < files.Length; i++)
			{
				files[i] = "~" + files[i].Replace(appPath, string.Empty);
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
			string make = FormatString(car.Make);
			string model = FormatString(car.Model);
			string carName = string.Format(CarNamePattern, make, model, car.YearFrom, car.YearTo);
			return carName;
		}

		#endregion Public methods

		#region Private methods

		private static string FormatString(string value)
		{
			// replace spaces with underscores
			string result = value.Trim().Replace(' ', '_');
			return result;
		}

		private static string GetCarName(CarViewModel car)
		{
			string make = FormatString(car.Make);
			string model = FormatString(car.Model);
			string carName = string.Format(CarNamePattern, make, model, car.YearFrom, car.YearTo);
			return carName;
		}

		private static string GetPath(string carName)
		{
			string path = Server.MapPath($"~/{Folder}/{carName}");
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