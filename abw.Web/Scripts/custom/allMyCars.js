define(['knockout'],
function (ko) {
	// todo: make common module with 'allCars.js'
	function allMyCars(viewModel) {
		var cars = viewModel.list;
		viewModel.list = ko.observableArray(cars);

		viewModel.deleteMyCar = function (myCar) {
			// todo: implement notification module
			var result = confirm('Are you sure?');
			if (result) {
				// todo: implement 'loader' module
				$.post('../myCars/delete/' + myCar.id).done(function (data) {
					if (!data.success) {
						alert(data.errorMessage);
					} else {
						viewModel.list.remove(myCar);
						alert('Car has been deleted');
					}
				}).fail(function () {
					alert('Sorry, an error occurred while processing your request');
				}).always(function () {
					// todo: hide loader
				});
			}
		};

		ko.applyBindings(viewModel);
	};

	return allMyCars;
});