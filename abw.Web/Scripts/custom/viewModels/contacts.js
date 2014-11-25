define(['main'], function (main) {
	var viewModel = {};

	function initGoogleMap(elements, title, center, markerPosition) {
		var googleMapsElement = $(elements).parent()[0];
		var googleMaps = window.google.maps;
		var settings = {
			center: center,
			zoom: 14
		};
		var map = new googleMaps.Map(googleMapsElement, settings);

		var marker = new googleMaps.Marker({
			position: markerPosition,
			title: title,
			animation: googleMaps.Animation.DROP
		});
		marker.setMap(map);

		var infoWindow = new googleMaps.InfoWindow({
			content: '<div class="scroll-fix">' + title + '</div>'
		});
		infoWindow.open(map, marker);
	}

	viewModel.initMarketMap = function (elements) {
		var TITLE = 'Авторынок "Малиновка", павильон 34/12н';

		var googleMaps = window.google.maps;
		var center = new googleMaps.LatLng(53.856967, 27.419279);
		var markerPosition = new googleMaps.LatLng(53.851716, 27.421215);

		initGoogleMap(elements, TITLE, center, markerPosition);
	};

	viewModel.initStorehouseMap = function (elements) {
		var TITLE = 'Склад на Скрипникова, 43';
		var LATITUDE = 53.898823;
		var LONGITUDE = 27.421431;

		var googleMaps = window.google.maps;
		var center = new googleMaps.LatLng(LATITUDE, LONGITUDE);
		var markerPosition = new googleMaps.LatLng(LATITUDE, LONGITUDE);

		initGoogleMap(elements, TITLE, center, markerPosition);
	};

	main.extendMainViewModel({ contactsPage: viewModel });
});