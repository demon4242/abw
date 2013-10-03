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
				int value = GetValueFromWebConfig<int>("GridPageSize");
				return value;
			}
		}

		private static T GetValueFromWebConfig<T>(string name) where T : IConvertible
		{
			string value = GetValueFromWebConfig(name);
			T result = (T)Convert.ChangeType(value, typeof(T));
			return result;
		}

		private static string GetValueFromWebConfig(string name)
		{
			string value = ConfigurationManager.AppSettings[name];
			if (string.IsNullOrWhiteSpace(value))
			{
				string errorMessage = string.Format("Value '{0}' has not been found in Web.config'", name);
				Logger.LogAndThrow(errorMessage);
			}
			return value;
		}
	}
}
