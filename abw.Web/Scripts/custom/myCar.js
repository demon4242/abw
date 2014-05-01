define(['knockout',
		'knockout-mapping',
		'baseCar',
		'notifications',
		'globalVars',
		'unobtrusive-validation'],
function (ko, koMapping, baseCar, notifications, globalVars) {
	function myCar(viewModel, errorMessages) {
		viewModel = baseCar(viewModel, errorMessages);

		viewModel.carMakeChanged = function (car) {
			var makeId = car.makeId();
			if (!makeId) {
				viewModel.models.removeAll();
				return;
			}
			$.get(globalVars.siteUrl + 'myCars/getCarModelsByMake?makeId=' + makeId).done(function (data) {
				// todo: make data lower case on server
				var lowerCaseData = [];
				ko.utils.arrayForEach(data, function (carModel) {
					lowerCaseData.push({
						value: carModel.Value,
						text: carModel.Text,
						selected: carModel.selected
					});
				});
				viewModel.models(lowerCaseData);
			}).fail(function () {
				notifications.error();
			});
		};

		ko.applyBindings(viewModel);
	}

	return myCar;
});