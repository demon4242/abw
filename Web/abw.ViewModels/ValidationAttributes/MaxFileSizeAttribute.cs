using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using abw.Logging;
using abw.Resources;

namespace abw.ViewModels.ValidationAttributes
{
	/// <summary>
	/// Restricts max file size.
	/// Applicable only for a List of HttpPostedFileBase
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class MaxFileSizeAttribute : ValidationAttribute, IClientValidatable
	{
		private readonly int _sizeInMb;

		public MaxFileSizeAttribute(int sizeInMb)
		{
			_sizeInMb = sizeInMb;
			ErrorMessageResourceType = typeof(ErrorMessages);
			ErrorMessageResourceName = "MaxFileSize";
		}

		public override string FormatErrorMessage(string name)
		{
			string errorMessage = string.Format(ErrorMessageString, name, _sizeInMb);
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
				int sizeInBytes = _sizeInMb * 1024 * 1024;

				bool isValid = file.ContentLength <= sizeInBytes;
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
				ValidationType = "maxfilesize",
				ErrorMessage = FormatErrorMessage(metadata.DisplayName),
			};
			rule.ValidationParameters.Add("sizeinmb", _sizeInMb);
			yield return rule;
		}
	}
}