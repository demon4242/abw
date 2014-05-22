define(['knockout'],
function (ko) {
	var viewModel = {};

	viewModel.initGoogleMaps = function (elements) {
		var TITLE = 'Авторынок "Малиновка", павильон 34/12н';

		var googleMapsElement = $(elements).parent()[0];
		var googleMaps = window.google.maps;
		var settings = {
			center: new googleMaps.LatLng(53.856980, 27.420352),
			zoom: 14
		};
		var map = new googleMaps.Map(googleMapsElement, settings);

		var marker = new googleMaps.Marker({
			position: new googleMaps.LatLng(53.851941, 27.421823),
			title: TITLE,
			animation: googleMaps.Animation.DROP
		});
		marker.setMap(map);

		var infoWindow = new googleMaps.InfoWindow({
			content: '<strong>' + TITLE + '</strong>'
		});
		infoWindow.open(map, marker);
	};

	ko.applyBindings(viewModel);
});