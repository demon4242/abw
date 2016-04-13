define(['main',
		'knockout'],
function(main, ko) {
	'use strict';

	var viewModel = {};

	var timeout;

	viewModel.array = ko.observableArray();

	var images;

	viewModel.activeIndex = ko.observable();
	viewModel.activeIndex.subscribe(function(oldValue) {
		if (!oldValue && oldValue !== 0) {
			return;
		}
		images[oldValue].classList.remove('active');
	}, null, 'beforeChange');
	viewModel.activeIndex.subscribe(function(newValue) {
		images[newValue].classList.add('active');
		clearTimeout(timeout);
		setSliderTimeout();
	});

	viewModel.init = function(elements) {
		images = $(elements).find('img');
		var array = [];
		for (var i = 0; i < images.length; i++) {
			array.push(i);
		}
		viewModel.array(array);
		viewModel.activeIndex(0);
	};

	viewModel.change = function(index) {
		viewModel.activeIndex(index);
	};

	viewModel.right = function(index) {
		var right = 30 * (viewModel.array().length - index);
		return right + 'px';
	};

	viewModel.moveLeft = function() {
		var activeIndex = viewModel.activeIndex();
		if (activeIndex === 0) {
			viewModel.activeIndex(viewModel.array().length - 1);
		} else {
			viewModel.activeIndex(--activeIndex);
		}
	};

	viewModel.moveRight = function() {
		var activeIndex = viewModel.activeIndex();
		if (activeIndex === viewModel.array().length - 1) {
			viewModel.activeIndex(0);
		} else {
			viewModel.activeIndex(++activeIndex);
		}
	};

	function setSliderTimeout() {
		timeout = setTimeout(viewModel.moveRight, 5000);
	}
	setSliderTimeout();

	main.extendMainViewModel({ indexPage: viewModel });
});