define(['knockout',
		'baseForm'],
function (ko, baseForm) {
	function signIn(viewModel, errorMessages) {
		// set name and password in order to maintain autocomplete
		viewModel.name = $('input[type=text]#Name').val();
		viewModel.password = $('input[type=password]#Password').val();

		viewModel = baseForm(viewModel, errorMessages, 'Войти');

		ko.applyBindings(viewModel);
	}

	return signIn;
});