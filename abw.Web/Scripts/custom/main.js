define(['jquery',
		'globalVars'],
function ($, globalVars) {
	var self = {};

	self.setActivePage = function () {
		function ifAdminPage(fullPath) {
			fullPath = fullPath.toLowerCase();
			var specialPages = ['cars', 'mycars'];
			var pathname = location.pathname.toLowerCase();
			for (var j = 0; j < specialPages.length; j++) {
				var searchPattern = globalVars.siteUrl.toLowerCase() + specialPages[i];
				if (fullPath.indexOf(searchPattern) === 0
					&& pathname.indexOf(searchPattern) === 0) {
					return true;
				}
			}
			return false;
		}

		var links = $('header ul.nav li a');
		for (var i = 0; i < links.length; i++) {
			var link = links[i];
			var linkFullPath = link.href.replace(location.origin, '');
			var isAdminPage = ifAdminPage(linkFullPath);

			// converts http://localhost/abw → http://localhost/abw/, http://localhost/abw/Home/CarsCatalogue → http://localhost/abw/Home/CarsCatalogue/
			function getHref(href) {
				href = href.toLowerCase();
				if (href[href.length - 1] !== '/') {
					href += '/';
				}
				return href;
			}

			var locationHref = getHref(location.href);
			var linkHref = getHref(link.href);
			if (isAdminPage || linkHref === locationHref) {
				$(link).removeAttr('href').closest('li').addClass('active');
				break;
			}
		}
	};

	return self;
});