define(function() {
	'use strict';

	var self = {};

	self.changeImage = function(viewModel, event) {
		var imageToShow = $(event.target).attr('data-image');
		$('.carousel [data-image]').removeClass('active');
		$('.carousel [data-image=' + imageToShow + ']').addClass('active');
	};

	return self;
});