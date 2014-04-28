define(['knockout',
		'knockout-mapping',
		'notifications',
		'globalVars',
		'unobtrusive-validation'],
function (ko, koMapping, notifications, globalVars) {
	function myCar(viewModel, errorMessages) {
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

		viewModel = koMapping.fromJS(viewModel);
		viewModel.errorMessages = errorMessages;
		ko.applyBindings(viewModel);
	}

	return myCar;
});