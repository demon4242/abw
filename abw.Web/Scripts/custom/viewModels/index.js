define(['main', 'modules/carousel'], function(main, carousel) {
	'use strict';

	var viewModel = {};

	viewModel.changeImage = carousel.changeImage;

	main.extendMainViewModel({ homePage: viewModel });
});