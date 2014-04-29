define(function () {
	var self = {};

	var LOADER_SELECTOR = '#spinnerComplex';

	self.show = function () {
		$(LOADER_SELECTOR).show();
	};

	self.hide = function () {
		$(LOADER_SELECTOR).hide();
	};

	return self;
});