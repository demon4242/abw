define(['knockout',
		'baseForm'],
function (ko, baseForm) {
	function signIn(viewModel, errorMessages) {
		viewModel = baseForm(viewModel, errorMessages);

		ko.applyBindings(viewModel);
	}

	return signIn;
});