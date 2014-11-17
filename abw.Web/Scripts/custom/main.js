define(['jquery'], function ($) {
	var self = {};

	self.setActivePage = function () {
		var links = $('header ul.nav li a');
		for (var i = 0; i < links.length; i++) {
			var link = links[i];

			// converts http://localhost/abw → http://localhost/abw/, http://localhost/abw/Home/Cars → http://localhost/abw/Home/Cars/
			function getHref(href) {
				href = href.toLowerCase();
				if (href[href.length - 1] !== '/') {
					href += '/';
				}
				return href;
			}

			var locationHref = getHref(location.href);
			var linkHref = getHref(link.href);
			if (linkHref === locationHref) {
				$(link).removeAttr('href').closest('li').addClass('active');
				break;
			}
		}
	};

	return self;
});