define(['knockout',
		'knockout-mapping',
		'addToValidationContext',
		'uniqueCarModels'],
function (ko, koMapping, addToValidationContext) {
	function car(viewModel, errorMessages) {
		function CarModel() {
			this.id = ko.observable(0);
			this.name = ko.observable();
		}

		viewModel.addToValidationContext = addToValidationContext;

		// adds new car model
		viewModel.addModel = function () {
			var carModel = new CarModel();
			viewModel.models.push(carModel);
		};

		// deletes car model
		viewModel.deleteCarModel = function (carViewModel) {
			var carModels = viewModel.models;
			if (carModels().length <= 1) {
				return;
			}
			carModels.remove(carViewModel);
		};

		viewModel = koMapping.fromJS(viewModel);
		viewModel.errorMessages = errorMessages;
		ko.applyBindings(viewModel);
	}

	return car;
});