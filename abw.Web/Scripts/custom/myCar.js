define(['knockout',
		'knockout-mapping',
		'unobtrusive-validation'],
function (ko, koMapping) {
	function myCar(viewModel, errorMessages) {
		viewModel.carMakeChanged = function (car) {
			var makeId = car.makeId();
			if (!makeId) {
				viewModel.models.removeAll();
				return;
			}
			$.get(window.siteUrl + 'myCars/getCarModelsByMake?makeId=' + makeId).done(function (data) {
				// todo: make daga lower case on server
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
				alert('Sorry, an error occurred while processing your request');
			});
		};

		viewModel = koMapping.fromJS(viewModel);
		viewModel.errorMessages = errorMessages;
		ko.applyBindings(viewModel);
	}

	return myCar;
});