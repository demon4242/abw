define(['knockout',
		'modules/notifications',
		'modules/loader',
		'main'],
function (ko, notifications, loader, main) {
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
			var yearTo = car.yearTo
				? car.yearTo
				: '';
			var nameHtml = '<strong>' + (car.make + ' ' + car.model + ' ' + car.yearFrom + '-' + yearTo) + '</strong>';
			notifications.confirm('Удалить машину <br />' + nameHtml, 'Вы уверены?', function () {
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

		var page = 1;

		viewModel.loadMore = function () {
			viewModel.loading(true);
			$.get(getUrl + '/' + ++page).done(function (data) {
				ko.utils.arrayForEach(data.list, function (car) {
					viewModel.list.push(car);
				});
				viewModel.totalCount(data.totalCount);

				if (viewModel.list().length === viewModel.totalCount()) {
					$(window).off('scroll', loadMoreByScrollDown);
				}
			}).fail(function () {
				notifications.error();
			}).always(function () {
				viewModel.loading(false);
			});
		};

		main.extendMainViewModel({ carsGrid: viewModel });

		function loadMoreByScrollDown() {
			if ($(window).scrollTop() !== ($(document).height() - $(window).height())) {
				return;
			}
			viewModel.loadMore();
		}

		$(window).on('scroll', loadMoreByScrollDown);
	};

	return carsGrid;
});