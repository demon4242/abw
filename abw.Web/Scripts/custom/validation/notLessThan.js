// ensures that one int value is not less than another one
define(['jquery',
		'unobtrusive-validation'],
function ($) {
	var METHOD = 'notLessThan';

	$.validator.addMethod(METHOD, function (value, element, property) {
		if (!value) {
			return true;
		}
		var intValue = parseInt(value);

		var anotherStringValue = $('#' + property).val();
		var anotherIntValue = parseInt(anotherStringValue);

		var isValid = intValue >= anotherIntValue;
		return isValid;
	});

	$.validator.unobtrusive.adapters.add(METHOD, ['property'], function (options) {
		options.messages[METHOD] = options.message;
		options.rules[METHOD] = options.params.property;
	});
});