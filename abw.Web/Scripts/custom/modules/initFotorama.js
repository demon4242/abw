define(['jquery',
		'fotorama'],
function ($) {
	'use strict';

	function initFotorama() {
		// jquery selector is required
		$('.fotorama').on('fotorama:ready', function (event) {
			var element = event.target || event.srcElement;
			element.style.visibility = 'visible';
		});
	}

	return initFotorama();
});