define(['knockout',
		'knockout-mapping',
		'unobtrusive-validation'],
function (ko, koMapping) {
	'use strict';

	function baseForm(viewModel, errorMessages, submitButtonText) {
		viewModel = koMapping.fromJS(viewModel);

		viewModel.loading = ko.observable(false);
		viewModel.submit = function (form) {
			if (!$(form).valid()) {
				return false;
			}
			viewModel.loading(true);
			return true;
		};

		viewModel.submitButtonText = submitButtonText || 'Сохранить';

		if (!errorMessages) {
			errorMessages = [];
		}
		viewModel.errorMessages = ko.observableArray(errorMessages);
		if (errorMessages.length) {
			$('body').animate({ scrollTop: $(document).height() }, 500);
		}

		viewModel.closeErrorMessages = function () {
			viewModel.errorMessages.removeAll();
		};

		return viewModel;
	}

	return baseForm;
});