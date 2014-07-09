// restricts max file size
define(['jquery',
		'unobtrusive-validation'],
function ($) {
	var METHOD = 'maxFileSize';

	$.validator.addMethod(METHOD, function (value, element, sizeInMb) {
		if (!element.files.length) {
			return true;
		}
		var fileSizeInBytes = element.files[0].size;
		var maxFileSizeInBytes = sizeInMb * 1024 * 1024;
		var result = fileSizeInBytes <= maxFileSizeInBytes;
		return result;
	});

	$.validator.unobtrusive.adapters.add(METHOD, ['sizeInMb'], function (options) {
		options.messages[METHOD] = options.message;
		options.rules[METHOD] = options.params.sizeInMb;
	});
});