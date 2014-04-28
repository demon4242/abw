// todo: implement beautiful notifications
define(function () {
	var self = {};

	self.success = function (message) {
		alert(message);
	};

	self.error = function (message) {
		if (!message) {
			message = 'Извините, произошла ошибка';
		}
		alert(message);
	};

	self.confirm = function (message) {
		var result = confirm(message);
		return result;
	};

	return self;
});