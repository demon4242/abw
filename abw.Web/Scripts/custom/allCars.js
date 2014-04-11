define(['knockout'],
function (ko) {
	function allCars(viewModel) {
		var cars = viewModel.list;
		viewModel.list = ko.observableArray(cars);

		viewModel.deleteCar = function (car) {
			// todo: implement notification module
			var result = confirm('Are you sure?');
			if (result) {
				// todo: implement 'loader' module
				$.get('../cars/delete/' + car.id).done(function (data) {
					if (!data.success) {
						alert(data.errorMessage);
					} else {
						viewModel.list.remove(car);
						alert('Car has been deleted');
					}
				}).fail(function () {
					alert('Sorry, an error occurred while processing your request');
				});
			}
		};

		ko.applyBindings(viewModel);
	};

	return allCars;
});