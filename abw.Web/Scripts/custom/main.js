define(['jquery',
		'globalVars'],
function ($, globalVars) {
	var self = {};

	self.setActivePage = function () {
		function ifSpecialPage(fullPath) {
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
			var isSpecialPage = ifSpecialPage(linkFullPath);

			// todo: make 'http://localhost/abw' and 'http://localhost/abw/', http://localhost/abw/Home/CarsCatalogue and http://localhost/abw/Home/CarsCatalogue/ the same
			if (isSpecialPage || link.href.toLowerCase() === location.href.toLowerCase()) {
				$(link).removeAttr('href').closest('li').addClass('active');
				break;
			}
		}
	};

	return self;
});