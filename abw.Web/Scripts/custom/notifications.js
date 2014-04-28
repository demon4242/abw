// todo: implement beautiful notifications
define(function () {
	var self = {};

	var notificationElementClass = '.notifications';

	self.success = function (message) {
		// todo: make common notify settings with self.error
		$(notificationElementClass).notify({
			type: 'success',
			message: { text: message },
			closable: true
		}).show();
	};

	self.error = function (message) {
		if (!message) {
			message = 'Извините, произошла ошибка';
		}
		$(notificationElementClass).notify({
			type: 'danger',
			message: { text: message },
			closable: true
		}).show();
	};

	self.confirm = function (message) {
		var result = confirm(message);
		return result;
	};

	return self;
});