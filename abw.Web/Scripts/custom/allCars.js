define(['knockout',
		'notifications',
		'loader'],
function (ko, notifications, loader) {
	function allCars(viewModel, url) {
		var cars = viewModel.list;
		viewModel.list = ko.observableArray(cars);

		viewModel.css = ko.computed(function () {
			var css = !viewModel.list().length
				? 'no-data'
				: null;
			return css;
		});

		viewModel.deleteCar = function (car) {
			var nameHtml = '<strong>' + (car.make || car.makeAndModel) + '</strong>';
			notifications.confirm('Удаление машины ' + nameHtml, 'Вы уверены?', function () {
				loader.show();
				$.post(url + '/' + car.id).done(function (data) {
					if (!data.success) {
						notifications.error(data.errorMessage);
					} else {
						viewModel.list.remove(car);
						notifications.success('Машина ' + nameHtml + ' удалена');
					}
				}).fail(function () {
					notifications.error();
				}).always(function () {
					loader.hide();
				});
			});
		};

		ko.applyBindings(viewModel);
	};

	return allCars;
});