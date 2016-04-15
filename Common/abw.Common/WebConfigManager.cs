using System;
using System.Configuration;
using abw.Logging;

namespace abw.Common
{
	public static class WebConfigManager
	{
		public static int GridPageSize
		{
			get
			{
				int value = GetValueFromWebConfig<int>(nameof(GridPageSize));
				return value;
			}
		}

		public static string XmlFilesPath
		{
			get
			{
				string value = GetValueFromWebConfig<string>(nameof(XmlFilesPath));
				return value;
			}
		}

		public static string CarsFileName
		{
			get
			{
				string value = GetValueFromWebConfig<string>(nameof(CarsFileName));
				return value;
			}
		}

		public static string UsersFileName
		{
			get
			{
				string value = GetValueFromWebConfig<string>(nameof(UsersFileName));
				return value;
			}
		}

		private static T GetValueFromWebConfig<T>(string name) where T : IConvertible
		{
			string value = ConfigurationManager.AppSettings[name];
			if (string.IsNullOrWhiteSpace(value))
			{
				string errorMessage = $"Value '{name}' has not been found in Web.config'";
				Logger.LogAndThrow(errorMessage);
			}
			T result = (T)Convert.ChangeType(value, typeof(T));
			return result;
		}
	}
}
