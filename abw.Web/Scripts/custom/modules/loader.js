define(function() {
	'use strict';

	var self = {};

	var loader;

	self.init = function(elements) {
		loader = $(elements).parent();
	};

	self.show = function() {
		loader.show();
	};

	self.hide = function() {
		loader.hide();
	};

	return self;
});