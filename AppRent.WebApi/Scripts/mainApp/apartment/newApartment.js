define([
    'durandal/system', 'durandal/app', 'mainApp/services/apartmentsService', 'knockout', 'jquery', 'mainApp/services/usersService'],
    function (system, app, apartmentService, ko, $,usersService) {

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
                photos: ko.observableArray()
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
                        house: self.apartment.house(),
                        corpus: self.apartment.corpus(),
                    },
                    photos: [
                    {
                        path: self.apartment.photos()[0]
                    }]
                }).done(function () {
                    app.showMessage("Добавлена новая квартира!");
                });
            }

        }



        return new NewApartment();
    });
