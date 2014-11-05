using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using abw.Resources;
using abw.Logging;

namespace abw.Attributes.Validation
{
	/// <summary>
	/// Restricts file extension.
	/// Applicable only for a List of HttpPostedFileBase
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class ValidFileExtensionsAttribute : ValidationAttribute, IClientValidatable
	{
		private readonly List<string> _extensions;

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

			List<HttpPostedFileBase> files = value as List<HttpPostedFileBase>;
			if (files == null)
			{
				Type attributeType = GetType();
				string errorMessage = string.Format(ErrorMessages.InvalidAttributeUsage, attributeType.Name, "List<HttpPostedFileBase>");
				Logger.Error(errorMessage);
				throw new Exception(errorMessage);
			}

			if (files.Count == 0 || files[0] == null)
			{
				return true;
			}

			foreach (HttpPostedFileBase file in files)
			{
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
				if (!isValid)
				{
					return false;
				}
			}
			return true;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			ModelClientValidationRule rule = new ModelClientValidationRule
			{
				ValidationType = "validfileextensions",
				ErrorMessage = FormatErrorMessage(metadata.DisplayName),
			};
			rule.ValidationParameters.Add("extensions", string.Join(",", _extensions));
			yield return rule;
		}
	}
}