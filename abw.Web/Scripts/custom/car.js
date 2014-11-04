define(['knockout',
		'knockout-mapping',
		'baseForm',
		'customValidation/maxFileSize',
		'customValidation/validFileExtensions'],
function (ko, koMapping, baseForm) {
	function car(viewModel, errorMessages) {
		viewModel = baseForm(viewModel, errorMessages);

		// automatically validates file input after its value has been changed
		viewModel.photosChanged = function (carViewModel, event) {
			var target = $(event.target || event.srcElement);
			var form = target.closest('form');
			var validator = form.validate();
			validator.element(target);
		};

		ko.applyBindings(viewModel);
	}

	return car;
});