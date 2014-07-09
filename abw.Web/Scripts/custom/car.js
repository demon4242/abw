define(['knockout',
		'knockout-mapping',
		'baseForm',
		'customValidation/addToValidationContext',
		'customValidation/uniqueCarModels'],
function (ko, koMapping, baseForm, addToValidationContext) {
	function car(viewModel, errorMessages) {
		viewModel = baseForm(viewModel, errorMessages);

		viewModel.addToValidationContext = addToValidationContext;

		function CarModel() {
			this.id = ko.observable(0);
			this.name = ko.observable();
		}

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

		ko.applyBindings(viewModel);
	}

	return car;
});