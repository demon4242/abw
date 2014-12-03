define(['main'], function (main) {
	var viewModel = {};

	viewModel.initMap = function (elements) {
		var TITLE = 'Авторынок "Малиновка", павильон 34/12н';

		var googleMaps = window.google.maps;
		var center = new googleMaps.LatLng(53.856967, 27.419279);
		var markerPosition = new googleMaps.LatLng(53.851716, 27.421215);

		var googleMapsElement = $(elements).parent()[0];
		var settings = {
			center: center,
			zoom: 14
		};
		var map = new googleMaps.Map(googleMapsElement, settings);

		var marker = new googleMaps.Marker({
			position: markerPosition,
			title: TITLE,
			animation: googleMaps.Animation.DROP
		});
		marker.setMap(map);

		var infoWindow = new googleMaps.InfoWindow({
			content: '<div class="scroll-fix">' + TITLE + '</div>'
		});
		infoWindow.open(map, marker);
	};

	main.extendMainViewModel({ contactsPage: viewModel });
});