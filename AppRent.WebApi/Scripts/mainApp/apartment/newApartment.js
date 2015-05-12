define([
    'durandal/system', 'durandal/app', 'mainApp/services/apartmentsService', 'knockout', 'jquery', 'mainApp/services/usersService', 'plugins/router'],
    function (system, app, apartmentService, ko, $,usersService,router) {

        var NewApartment = function () {
            
        }

        NewApartment.prototype.activate = function (id) {
            var self = this;
            self.apartment = {
                price: ko.observable(),
                city: ko.observable(),
                district: ko.observable(),
                street: ko.observable(),
                house: ko.observable(),
                corpus: ko.observable(),
                roomsCount: ko.observable(),
                description: ko.observable(),
                photos: ko.observableArray(),
                fileInput: ko.observable(),
                fileName: ko.observable()
            };

            self.currentUserId = ko.observable();

            usersService.getCurrentUser().done(function (user) {
                self.currentUserId(user.Id);
            });
            
            self.save = function (apartment) {
                apartmentService.saveApartment({
                    description: self.apartment.description(),
                    price: self.apartment.price(),
                    roomsCount: self.apartment.roomsCount(),
                    user: { id: self.currentUserId() },
                    address: {
                        city: self.apartment.city(),
                        district: self.apartment.district(),
                        street: self.apartment.street(),
                        houseNumber: self.apartment.house(),
                        corpus: self.apartment.corpus(),
                    },
                    photos: [
                    {
                        name: self.apartment.fileName(),
                        base64: self.apartment.fileInput()
                    }]
                }).done(function () {
                    app.showMessage("Добавлена новая квартира!").then(function () {
                        router.navigate('#');
                    });
                    
                });
            }

        }

        ko.bindingHandlers['file'] = {
            init: function (element, valueAccessor, allBindings) {
                var fileContents, fileName, allowed, prohibited, reader;

                if ((typeof valueAccessor()) === "function") {
                    fileContents = valueAccessor();
                } else {
                    fileContents = valueAccessor()['data'];
                    fileName = valueAccessor()['name'];

                    allowed = valueAccessor()['allowed'];
                    if ((typeof allowed) === 'string') {
                        allowed = [allowed];
                    }

                    prohibited = valueAccessor()['prohibited'];
                    if ((typeof prohibited) === 'string') {
                        prohibited = [prohibited];
                    }

                    reader = (valueAccessor()['reader']);
                }

                reader || (reader = new FileReader());
                reader.onloadend = function () {
                    fileContents(reader.result);
                }

                var handler = function () {
                    var file = element.files[0];

                    // Opening the file picker then canceling will trigger a 'change'
                    // event without actually picking a file.
                    if (file === undefined) {
                        fileContents(null)
                        return;
                    }

                    if (allowed) {
                        if (!allowed.some(function (type) { return type === file.type })) {
                            console.log("File " + file.name + " is not an allowed type, ignoring.")
                            fileContents(null)
                            return;
                        }
                    }

                    if (prohibited) {
                        if (prohibited.some(function (type) { return type === file.type })) {
                            console.log("File " + file.name + " is a prohibited type, ignoring.")
                            fileContents(null)
                            return;
                        }
                    }

                    reader.readAsDataURL(file); // A callback (above) will set fileContents
                    if (typeof fileName === "function") {
                        fileName(file.name)
                    }
                }

                ko.utils.registerEventHandler(element, 'change', handler);
            }
        }

        return new NewApartment();
    });
