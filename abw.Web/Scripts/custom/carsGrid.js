define(['knockout',
		'notifications',
		'loader'],
function (ko, notifications, loader) {
	function carsGrid(viewModel, deleteUrl, getUrl) {
		viewModel.list = ko.observableArray(viewModel.list);
		viewModel.totalCount = ko.observable(viewModel.totalCount);

		viewModel.css = ko.computed(function () {
			var css = !viewModel.list().length
				? 'no-data'
				: null;
			return css;
		});

		viewModel.deleteCar = function (car) {
			var nameHtml = '<strong>' + (car.make || car.makeAndModel + ' ' + car.year) + '</strong>';
			notifications.confirm('Удаление машины ' + nameHtml, 'Вы уверены?', function () {
				loader.show();
				$.post(deleteUrl + '/' + car.id).done(function (data) {
					if (!data.success) {
						notifications.error(data.errorMessage);
					} else {
						viewModel.list.remove(car);
						viewModel.totalCount(viewModel.totalCount() - 1);
						notifications.success('Машина ' + nameHtml + ' удалена');
					}
				}).fail(function () {
					notifications.error();
				}).always(function () {
					loader.hide();
				});
			});
		};

		viewModel.pageInfo = ko.computed(function () {
			var pageInfo = '1-' + viewModel.list().length + ' of ' + viewModel.totalCount();
			return pageInfo;
		});
		viewModel.loading = ko.observable(false);

		ko.applyBindings(viewModel);

		var page = 1;

		function loadMore() {
			if ($(window).scrollTop() !== ($(document).height() - $(window).height())) {
				return;
			}
			if (viewModel.list().length === viewModel.totalCount()) {
				$(window).off('scroll', loadMore);
				return;
			}
			viewModel.loading(true);
			$.get(getUrl + '?page=' + ++page).done(function (data) {
				ko.utils.arrayForEach(data.list, function (car) {
					viewModel.list.push(car);
				});
				viewModel.totalCount(data.totalCount);
			}).fail(function () {
				notifications.error();
			}).always(function () {
				viewModel.loading(false);
			});
		}

		$(window).on('scroll', loadMore);
	};

	return carsGrid;
});