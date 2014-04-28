// ensures that car has not duplicate models
define(['jquery', 'unobtrusive-validation'],
function ($) {
	var METHOD = 'unique-car-models';

	$.validator.addMethod(METHOD, function (value, element) {
		var carModelValue = value.trim().toLowerCase();
		var elements = $('.car-model input[type=text][name$="].Name"]');
		for (var i = 0; i < elements.length; i++) {
			var carModelElement = elements[i];
			if (carModelElement !== element && carModelElement.value === carModelValue) {
				return false;
			}
		}
		return true;
	});

	$.validator.unobtrusive.adapters.add(METHOD, function (options) {
		options.messages[METHOD] = options.message;
		options.rules[METHOD] = options.params;
	});
});