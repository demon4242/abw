using System;
using System.Reflection;
using log4net;

namespace abw.Logging
{
	public static class Logger
	{
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public static void Error(string message)
		{
			Log.Error(message);
		}

		public static void LogAndThrow(string message)
		{
			Error(message);
			throw new Exception(message);
		}
	}
}
