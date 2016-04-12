define(['jquery',
		'fotorama'],
function($) {
	'use strict';

	function initFotorama() {
		// jquery selector is required
		var fotorama = $('.fotorama');

		fotorama.on('fotorama:ready', function() {
			fotorama.parent().css('visibility', 'visible');
		});
	}

	return initFotorama();
});