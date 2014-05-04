define(['knockout',
		'knockout-mapping',
		'baseForm',
		'notifications',
		'globalVars',
		'unobtrusive-validation'],
function (ko, koMapping, baseForm, notifications, globalVars) {
	function myCar(viewModel, errorMessages) {
		viewModel = baseForm(viewModel, errorMessages);

		viewModel.carMakeChanged = function (car) {
			var makeId = car.makeId();
			if (!makeId) {
				viewModel.models.removeAll();
				return;
			}
			$.get(globalVars.siteUrl + 'myCars/getCarModelsByMake?makeId=' + makeId).done(function (data) {
				viewModel.models(data);
			}).fail(function () {
				notifications.error();
			});
		};

		ko.applyBindings(viewModel);
	}

	return myCar;
});