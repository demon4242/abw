// restricts max file size
define(['jquery',
		'unobtrusive-validation'],
function ($) {
	'use strict';

	var METHOD = 'maxFileSize';

	$.validator.addMethod(METHOD, function (value, element, sizeInMb) {
		var files = element.files;
		if (!files.length) {
			return true;
		}

		for (var i = 0; i < files.length; i++) {
			var fileSizeInBytes = files[i].size;
			var maxFileSizeInBytes = sizeInMb * 1024 * 1024;
			var isValid = fileSizeInBytes <= maxFileSizeInBytes;
			if (!isValid) {
				return false;
			}
		}
		return true;
	});

	$.validator.unobtrusive.adapters.add(METHOD, ['sizeInMb'], function (options) {
		options.messages[METHOD] = options.message;
		options.rules[METHOD] = options.params.sizeInMb;
	});
});