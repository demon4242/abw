define(['jquery', 'unobtrusive-validation'],
function ($) {
	$.validator.addMethod('uniqueCarModels', function (value, a, b, c, d) {
		return false;
		debugger;
		//if (value !== 'Security') {
		//	return true;
		//}
		//var securityLegsCount = 0;
		//var legTypes = $('.removable-item select[name*=LegType]');
		//var i;
		//for (i = 0; i < legTypes.length; i++) {
		//	if (legTypes[i].value === 'Security') {
		//		if (securityLegsCount === 1) {
		//			return false;
		//		}
		//		securityLegsCount++;
		//	}
		//}
		//return true;
	});

	$.validator.unobtrusive.adapters.add('uniqueCarModels', function (options) {
		options.messages['uniqueCarModels'] = options.message;
		options.rules['uniqueCarModels'] = options.params;
	});
});