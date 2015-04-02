define(['jquery',
		'fotorama'],
function ($) {
	'use strict';

	function initFotorama() {
		// jquery selector is required
		var fotorama = $('.fotorama');
		var fotoramaWrapper = fotorama.parent();
		var totalCount = fotorama.length;
		var count = 0;

		fotorama.on('fotorama:ready', function () {
			count++;
			if (count === totalCount) {
				fotoramaWrapper.css('visibility', 'visible');
			}
		});
	}

	return initFotorama();
});