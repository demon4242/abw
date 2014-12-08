define(function () {
	'use strict';

	var self = {};

	var ERROR_MESSAGE = 'Извините, произошла ошибка';

	var notification;
	var confirmModal;

	function showNotification(type, message) {
		notification.notify({
			type: type,
			message: { html: message },
			closable: true
		}).show();
	};

	self.init = function (elements) {
		notification = $(elements).parent();
	};

	self.initConfirm = function (elements) {
		confirmModal = $(elements).parent();
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
		confirmModal.find('.modal-title').html(title);
		confirmModal.find('.modal-body').html(message);
		var yesButton = confirmModal.find('.btn-primary');
		yesButton.off('click');
		yesButton.on('click', function () {
			confirmModal.modal('hide');
			yesHandler();
		});
		confirmModal.modal();
	};

	return self;
});