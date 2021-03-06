﻿define(['jquery',
		'knockout',
		'modules/loader',
		'modules/notifications',
		'bootstrap',
		'bindings/modal'],
function($, ko, loader, notifications) {
	'use strict';

	var modulesToLoadArray = [];
	var modulesCallbacks = [];

	function loadModules(modules, callback) {
		modulesToLoadArray.push(modules);
		modulesCallbacks.push(callback);
	};

	function MainViewModel() {
		var that = this;

		// converts http://localhost/abw → http://localhost/abw/, http://localhost/abw/Home/Cars → http://localhost/abw/Home/Cars/
		function getHref(href) {
			href = href.toLowerCase();
			if (href[href.length - 1] !== '/') {
				href += '/';
			}
			return href;
		}

		this.signInModalIsOpened = ko.observable();

		this.openSignInModal = function() {
			that.signInModalIsOpened(true);
		};

		this.initLoader = loader.init;

		this.initNotification = notifications.init;
		this.initConfirm = notifications.initConfirm;

		this.setActivePage = function(elements) {
			var links = $(elements).parent().find('a');
			for (var i = 0; i < links.length; i++) {
				var link = links[i];

				var locationHref = getHref(location.href);
				var linkHref = getHref(link.href);
				if (linkHref === locationHref) {
					$(link).removeAttr('href').addClass('active');
					break;
				}
			}
		}
	}

	var mainViewModel = new MainViewModel();

	function extendMainViewModel(viewModel) {
		$.extend(mainViewModel, viewModel);
	};

	function updateMainViewModel(propName, value) {
		var prop = mainViewModel[propName];
		if (ko.isObservable(prop)) {
			prop(value);
		} else {
			mainViewModel[propName] = value;
		}
	}

	function applyBindings() {
		function mainCallBack() {
			ko.applyBindings(mainViewModel);
		}

		if (modulesToLoadArray.length === 0) {
			mainCallBack();
		} else {
			var i = 0;

			(function load() {
				require(modulesToLoadArray[i], function() {
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
		updateMainViewModel: updateMainViewModel,
		applyBindings: applyBindings
	};
	return self;
});