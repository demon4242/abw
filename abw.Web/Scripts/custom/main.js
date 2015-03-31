define(['jquery',
		'knockout',
		'modules/loader',
		'modules/notifications',
		'bootstrap',
		'bindings/modal'],
function ($, ko, loader, notifications) {
	'use strict';

	// converts http://localhost/abw → http://localhost/abw/, http://localhost/abw/Home/Cars → http://localhost/abw/Home/Cars/
	function getHref(href) {
		href = href.toLowerCase();
		if (href[href.length - 1] !== '/') {
			href += '/';
		}
		return href;
	}

	function setActivePage() {
		var links = $('header ul.nav li a');
		for (var i = 0; i < links.length; i++) {
			var link = links[i];

			var locationHref = getHref(location.href);
			var linkHref = getHref(link.href);
			if (linkHref === locationHref) {
				$(link).removeAttr('href').closest('li').addClass('active');
				break;
			}
		}
	}

	var modulesToLoadArray = [];
	var modulesCallbacks = [];

	function loadModules(modules, callback) {
		modulesToLoadArray.push(modules);
		modulesCallbacks.push(callback);
	};

	function MainViewModel() {
		var self = this;

		this.signInModalIsOpened = ko.observable();

		this.openSignInModal = function () {
			self.signInModalIsOpened(true);
		};

		this.initLoader = loader.init;

		this.initNotification = notifications.init;
		this.initConfirm = notifications.initConfirm;
	}

	var mainViewModel = new MainViewModel();

	function extendMainViewModel(viewModel) {
		$.extend(mainViewModel, viewModel);
	};

	function applyBindings() {
		setActivePage();

		function mainCallBack() {
			ko.applyBindings(mainViewModel);
		}

		if (modulesToLoadArray.length === 0) {
			mainCallBack();
		} else {
			var i = 0;

			(function load() {
				require(modulesToLoadArray[i], function () {
					var modulesCallback = modulesCallbacks[i];
					if (modulesCallback) {
						modulesCallback.apply(null, arguments);
					}
					i++;
					if (i === modulesToLoadArray.length) {
						mainCallBack();
					} else {
						load();
					}
				});
			}());
		}
	};

	var self = {
		loadModules: loadModules,
		extendMainViewModel: extendMainViewModel,
		applyBindings: applyBindings
	};
	return self;
});