define(['knockout',
		'knockout-mapping',
		'uniqueCarModels'],
function (ko, koMapping) {
	function car(viewModel, errorMessages) {
		function CarModel() {
			this.id = ko.observable(0);
			this.name = ko.observable();
		}

		// adds dom elements to jQuery validation context
		viewModel.addToValidationContext = function (elements) {
			var form;
			var dataValElementNames = [];
			// validation rules from jquery validation object
			var jqueryRules;
			// validation rules from DOM
			var domRules;

			if (!(elements instanceof Array)) {
				elements = [elements];
			}

			ko.utils.arrayForEach(elements, function (element) {
				// ignore element in array if its nodeType is not ELEMENT_NODE
				if (element.nodeType === 1) {
					var dataValElements = [];
					if ($(element).attr('data-val')) {
						dataValElements.push(element);
					} else {
						dataValElements = $(element).find('[data-val]');
					}
					if (dataValElements.length) {
						if (!form) {
							form = $(dataValElements).closest('form');
						}
						ko.utils.arrayForEach(dataValElements, function (dataValElement) {
							// adds rules to 'domRules'
							$.validator.unobtrusive.parseElement(dataValElement);
							dataValElementNames.push(dataValElement.name);
						});
					}
				}
			});

			if (!form) {
				return;
			}

			jqueryRules = form.validate().settings.rules;
			domRules = form.data('unobtrusiveValidation').options.rules;

			ko.utils.arrayForEach(dataValElementNames, function (name) {
				var jqueryMessages, domMessages;
				if (!jqueryRules[name] && domRules[name]) {
					jqueryRules[name] = domRules[name];
					// add error messages if necessary
					jqueryMessages = form.validate().settings.messages;
					domMessages = form.data('unobtrusiveValidation').options.messages;
					if (!jqueryMessages[name] && domMessages[name]) {
						jqueryMessages[name] = domMessages[name];
					}
				}
			});
		};

		// adds new car model
		viewModel.addModel = function () {
			var carModel = new CarModel();
			viewModel.models.push(carModel);
		};

		// deletes car model
		viewModel.deleteCarModel = function (carViewModel) {
			var carModels = viewModel.models;
			if (carModels().length <= 1) {
				return;
			}
			carModels.remove(carViewModel);
		};

		viewModel = koMapping.fromJS(viewModel);
		viewModel.errorMessages = errorMessages;
		ko.applyBindings(viewModel);
	}

	return car;
});