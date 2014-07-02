using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using abw.Resources;
using abw.Logging;

namespace abw.Attributes.Validation
{
	// todo: add client validation
	/// <summary>
	/// Restricts file extension
	/// </summary>
	public class ValidFileExtensionsAttribute : ValidationAttribute
	{
		#region Public

		/// <param name="extensions">extensions separated by comma</param>
		public ValidFileExtensionsAttribute(string extensions)
		{
			ErrorMessageResourceType = typeof(ErrorMessages);
			ErrorMessageResourceName = "ValidFileExtensions";
			_extensions = extensions.Split(',').Select(m => m.Trim().ToLower()).ToList();
		}

		public override string FormatErrorMessage(string name)
		{
			string extensions = string.Join(", ", _extensions);
			string errorMessage = string.Format(ErrorMessageString, name, extensions);
			return errorMessage;
		}

		public override bool IsValid(object value)
		{
			if (value == null)
			{
				return true;
			}

			HttpPostedFileBase file = GetFileFromValue(value, GetType());

			string extension = Path.GetExtension(file.FileName);
			if (string.IsNullOrWhiteSpace(extension))
			{
				const string errorMessage = "File extension cannot be determined";
				Logger.Error(errorMessage);
				throw new Exception(errorMessage);
			}
			// convert .jpg → jpg, .gif → gif, etc.
			extension = extension.Replace(".", string.Empty).ToLower();

			bool isValid = _extensions.Contains(extension);
			return isValid;
		}

		#endregion Public

		#region Private

		private readonly List<string> _extensions;

		/// <summary>
		/// Converts object into HttpPostedFileBase
		/// </summary>
		private static HttpPostedFileBase GetFileFromValue(object value, Type attributeType)
		{
			HttpPostedFileBase file = value as HttpPostedFileBase;
			if (file == null)
			{
				string errorMessage = string.Format("'{0}' can be used only with properties of type '{1}'", attributeType.Name, typeof(HttpPostedFileBase).Name);
				Logger.Error(errorMessage);
				throw new Exception(errorMessage);
			}
			return file;
		}

		#endregion Private
	}
}