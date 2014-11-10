using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;
using abw.Logging;

namespace abw.Attributes.Validation
{
	/// <summary>
	/// Ensures that one int value is not less than another one
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class NotLessThanAttribute : ValidationAttribute, IClientValidatable
	{
		private readonly string _anotherPropertyName;

		public NotLessThanAttribute(string anotherPropertyName)
		{
			_anotherPropertyName = anotherPropertyName;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return ValidationResult.Success;
			}

			int intValue;
			bool parseResult = int.TryParse(value.ToString(), out intValue);
			if (!parseResult)
			{
				string errorMessage = string.Format("Attribute '{0}' is only applicable for properties of integer type", GetType().Name);
				Logger.Error(errorMessage);
				throw new Exception(errorMessage);
			}

			PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(_anotherPropertyName);
			if (propertyInfo == null)
			{
				string errorMessage = string.Format("Property '{0}' has not been found in the model", _anotherPropertyName);
				Logger.Error(errorMessage);
				throw new Exception(errorMessage);
			}
			object objectValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);

			int anotherIntValue;
			parseResult = int.TryParse(objectValue.ToString(), out anotherIntValue);
			if (!parseResult)
			{
				const string errorMessage = "Another property must be of integer type";
				Logger.Error(errorMessage);
				throw new Exception(errorMessage);
			}

			bool isValid = intValue >= anotherIntValue;
			if (isValid)
			{
				return ValidationResult.Success;
			}

			ValidationResult validationResult = new ValidationResult(ErrorMessage);
			return validationResult;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			ModelClientValidationRule rule = new ModelClientValidationRule
			{
				ValidationType = "notlessthan",
				ErrorMessage = ErrorMessageString
			};
			rule.ValidationParameters.Add("property", _anotherPropertyName);
			yield return rule;
		}
	}
}