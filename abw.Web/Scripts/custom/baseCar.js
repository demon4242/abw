define(['knockout',
		'knockout-mapping'],
function (ko, koMapping) {
	function baseCar(viewModel, errorMessages) {
		viewModel = koMapping.fromJS(viewModel);

		viewModel.loading = ko.observable(false);
		viewModel.submit = function (form) {
			if (!$(form).valid()) {
				return false;
			}
			viewModel.loading(true);
			return true;
		};

		viewModel.errorMessages = errorMessages;

		return viewModel;
	}

	return baseCar;
});