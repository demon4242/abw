define(['jquery',
		'knockout'],
function ($, ko) {
	'use strict';

	function modal($element, value) {
		var valueUnwrapped = ko.unwrap(value);
		if (valueUnwrapped) {
			$element.modal();
		}
	}

	ko.bindingHandlers.modal = {
		init: function (element, valueAccessor) {
			var $element = $(element);
			var value = valueAccessor();

			$element.on('hidden.bs.modal', function () {
				value(false);
			});

			modal($element, value);
		},
		update: function (element, valueAccessor) {
			var $element = $(element);
			var value = valueAccessor();

			modal($element, value);
		}
	};
});