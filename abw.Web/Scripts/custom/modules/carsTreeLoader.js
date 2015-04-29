define(['jquery',
		'knockout',
		'modules/notifications',
		'main'],
function ($, ko, notifications, main) {
	main.extendMainViewModel({ carsTree: ko.observableArray() });

	var PATH = '/abw';
	var href = location.protocol + '//' + location.host;
	if (location.pathname.indexOf(PATH) === 0) {
		href += PATH;
	}
	href += '/';

	var result = $.get(href + 'carsTree').done(function (data) {
		var carsTree = [];
		ko.utils.arrayForEach(data, function (car) {
			var make = {
				text: car.make,
				href: href + 'cars/' + car.make.toLowerCase()
			};
			var models = [];
			ko.utils.arrayForEach(car.models, function (model) {
				models.push({
					text: model,
					href: make.href + '/' + model.toLowerCase()
				});
			});
			carsTree.push({
				make: make,
				models: models
			});
		});
		main.updateMainViewModel('carsTree', carsTree);
	}).fail(function () {
		notifications.error();
	});
	return result;
});