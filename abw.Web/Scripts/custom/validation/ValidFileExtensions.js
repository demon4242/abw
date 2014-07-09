// restricts file extension
define(['jquery',
		'unobtrusive-validation'],
function ($) {
	var METHOD = 'validFileExtensions';

	$.validator.addMethod(METHOD, function (fileName, element, extensions) {
		if (!fileName) {
			return true;
		}
		var regExp = /(?:\.([^.]+))?$/;
		var extension = regExp.exec(fileName)[1];
		extensions = extensions.split(',');
		var result = extensions.indexOf(extension) !== -1;
		return result;
	});

	$.validator.unobtrusive.adapters.add(METHOD, ['extensions'], function (options) {
		options.messages[METHOD] = options.message;
		options.rules[METHOD] = options.params.extensions;
	});
});