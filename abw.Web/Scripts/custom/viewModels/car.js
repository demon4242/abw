define(['jquery',
		'viewModels/baseForm',
		'main',
		'customValidation/maxFileSize',
		'customValidation/validFileExtensions',
		'customValidation/notLessThan'],
function ($, baseForm, main) {
	function car(viewModel, errorMessages) {
		viewModel = baseForm(viewModel, errorMessages);

		// automatically validates file input after its value has been changed
		viewModel.photosChanged = function (carViewModel, event) {
			var target = $(event.target || event.srcElement);
			var form = target.closest('form');
			var validator = form.validate();
			validator.element(target);
		};

		main.extendMainViewModel({ carForm: viewModel });
	}

	return car;
});