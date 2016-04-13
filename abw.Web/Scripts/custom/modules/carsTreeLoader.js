define(['jquery',
		'knockout',
		'modules/notifications',
		'modules/constants',
		'main'],
function($, ko, notifications, constants, main) {
	'use strict';

	main.extendMainViewModel({ carsTree: ko.observableArray() });

	var href = location.protocol + '//' + location.host + constants.APP_URL;

	var result = $.get(href + 'carsTree').done(function(data) {
		var carsTree = [];
		ko.utils.arrayForEach(data, function(car) {
			var make = {
				text: car.make,
				href: href + 'cars/' + car.make.toLowerCase()
			};
			var models = [];
			ko.utils.arrayForEach(car.models, function(model) {
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
	}).fail(function() {
		notifications.error();
	});
	return result;
});