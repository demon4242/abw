define(function () {
	var self = {};

	var ERROR_MESSAGE = 'Извините, произошла ошибка';

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
			message = ERROR_MESSAGE;
		}
		showNotification('danger', message);
	};

	self.confirm = function (title, message, yesHandler) {
		var modal = $('#confirm');
		modal.find('.modal-title').html(title);
		modal.find('.modal-body').html(message);
		var yesButton = modal.find('.btn-primary');
		yesButton.off('click');
		yesButton.on('click', function () {
			modal.modal('hide');
			yesHandler();
		});
		modal.modal();
	};

	return self;
});