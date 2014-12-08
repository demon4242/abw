// restricts file extension
define(['jquery',
		'unobtrusive-validation'],
function ($) {
	'use strict';

	var METHOD = 'validFileExtensions';

	$.validator.addMethod(METHOD, function (value, element, extensions) {
		var files = element.files;
		if (!files.length) {
			return true;
		}

		extensions = extensions.split(',');
		for (var i = 0; i < files.length; i++) {
			var fileName = files[i].name;
			var regExp = /(?:\.([^.]+))?$/;
			var extension = regExp.exec(fileName)[1].toLowerCase();
			var isValid = extensions.indexOf(extension) !== -1;
			if (!isValid) {
				return false;
			}
		}
		return true;
	});

	$.validator.unobtrusive.adapters.add(METHOD, ['extensions'], function (options) {
		options.messages[METHOD] = options.message;
		options.rules[METHOD] = options.params.extensions;
	});
});