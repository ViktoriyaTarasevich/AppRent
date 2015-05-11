define([
    'durandal/system',
    'durandal/app',
    'mainApp/services/apartmentsService',
    'knockout',
    'jquery',
    'mainApp/services/usersService'],
    function (system, app, apartmentService, ko, $,usersService) {

        var MyApartments = function () {

        }

        MyApartments.prototype.activate = function (id) {
            var self = this;
            self.apartmets = ko.observableArray();

            apartmentService.getApartmentsByUserId(id).then(function (items) {
                self.apartmets(items);
            });

            self.currentUserId = ko.observable();

            usersService.getCurrentUser().done(function (user) {
                self.currentUserId(user.Id);
            });

            self.currentUserId.subscribe(function (item) {
                if (item === id) {
                    usersService.getCurrentUser().done(function (user) {
                        self.currentUserId(user.Id);
                    });
                }
            });

        }

        

        return new MyApartments();
    });
