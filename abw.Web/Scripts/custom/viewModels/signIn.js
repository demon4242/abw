define(['viewModels/baseForm',
		'main'],
function (baseForm, main) {
	'use strict';

	function signIn(viewModel, errorMessages) {
		// set name and password in order to maintain autocomplete
		viewModel.name = $('input[type=text]#Name').val();
		viewModel.password = $('input[type=password]#Password').val();

		viewModel = baseForm(viewModel, errorMessages, 'Войти');

		main.extendMainViewModel({ signInForm: viewModel });
	}

	return signIn;
});