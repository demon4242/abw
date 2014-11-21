define(['jquery',
		'knockout'],
function ($, ko) {
	function setActivePage() {
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
	}

	var modulesToLoad;
	var modulesCallback;

	function loadModules(modules, callback) {
		modulesToLoad = modules;
		modulesCallback = callback;
	};

	var mainViewModel = {
		openSignInModal: function () {
			// todo: use knockout instead of jquery selector
			$('#signInModal').modal();
		}
	};

	function extendMainViewModel(viewModel) {
		$.extend(mainViewModel, viewModel);
	};

	function applyBindings() {
		setActivePage();

		function mainCallBack() {
			ko.applyBindings(mainViewModel);
		}

		if (!modulesToLoad) {
			mainCallBack();
		} else {
			require(modulesToLoad, function () {
				if (modulesCallback) {
					modulesCallback.apply(null, arguments);
				}
				mainCallBack();
			});
		}
	};

	var self = {
		loadModules: loadModules,
		extendMainViewModel: extendMainViewModel,
		applyBindings: applyBindings
	};
	return self;
});