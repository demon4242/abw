define(['knockout'],
function (ko) {
	// todo: make common module with 'allCars.js'
	function allMyCars(viewModel) {
		var cars = viewModel.list;
		viewModel.list = ko.observableArray(cars);

		ko.applyBindings(viewModel);
	};

	return allMyCars;
});