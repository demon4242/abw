define(['knockout',
		'knockout-mapping',
		'baseForm',
		'notifications',
		'globalVars',
		'unobtrusive-validation',
		'customValidation/maxFileSize',
		'customValidation/validFileExtensions'],
function (ko, koMapping, baseForm, notifications, globalVars) {
	function myCar(viewModel, errorMessages) {
		viewModel = baseForm(viewModel, errorMessages);

		viewModel.carMakeChanged = function (car) {
			var makeId = car.makeId();
			if (!makeId) {
				viewModel.models.removeAll();
				return;
			}
			$.get(globalVars.siteUrl + 'myCars/getCarModelsByMake?makeId=' + makeId).done(function (data) {
				viewModel.models(data);
			}).fail(function () {
				notifications.error();
			});
		};

		// automatically validates file input after its value has been changed
		viewModel.photoChanged = function (myCarViewModel, event) {
			var target = $(event.target || event.srcElement);
			var form = target.closest('form');
			var validator = form.validate();
			validator.element(target);
		}

		ko.applyBindings(viewModel);
	}

	return myCar;
});