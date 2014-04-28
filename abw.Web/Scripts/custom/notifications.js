define(function () {
	var self = {};

	function showNotification(type, message) {
		$('#notification').notify({
			type: type,
			message: { html: message },
			closable: true
		}).show();
	};

	self.success = function (message) {
		showNotification('success', message);
	};

	self.error = function (message) {
		if (!message) {
			message = 'Извините, произошла ошибка';
		}
		showNotification('danger', message);
	};

	// todo: implement custom bootstrap confirm
	self.confirm = function (message) {
		var result = confirm(message);
		return result;
	};

	return self;
});