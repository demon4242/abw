define(['jquery',
		'knockout',
		'modules/notifications',
		'main'],
function ($, ko, notifications, main) {
	main.extendMainViewModel({ carsTree: ko.observableArray() });
	var result = $.get('carsTree').done(function (data) {
		main.updateMainViewModel('carsTree', data);
	}).fail(function () {
		notifications.error();
	});
	return result;
});