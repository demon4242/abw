define(['knockout',
		'knockout-mapping',
		'unobtrusive-validation'],
function (ko, koMapping) {
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

		viewModel.errorMessages = errorMessages;
		if (errorMessages.length) {
			$('body').animate({ scrollTop: $(document).height() }, 500);
		}

		return viewModel;
	}

	return baseForm;
});