define(['jquery',
		'viewModels/baseForm',
		'main',
		'modules/notifications'],
function ($, baseForm, main, notifications) {
	'use strict';

	function signInModal(viewModel, errorMessages) {
		// set name and password in order to maintain autocomplete
		viewModel.name = $('input[type=text]#Name').val();
		viewModel.password = $('input[type=password]#Password').val();

		viewModel = baseForm(viewModel, errorMessages, 'Войти');

		viewModel.submit = function (form) {
			if (!$(form).valid()) {
				return false;
			}

			var model = $(form).serialize();
			viewModel.loading(true);
			$.post(form.action, model).done(function (data) {
				if (data.success) {
					location.href = data.returnUrl;
				} else {
					viewModel.errorMessages(data.errorMessages);
					viewModel.loading(false);
				}
			}).fail(function () {
				notifications.error();
				viewModel.loading(false);
			});

			return false;
		};

		main.extendMainViewModel({ signInModal: viewModel });
	}

	return signInModal;
});