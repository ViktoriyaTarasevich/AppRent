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

        MyApartments.prototype.activate = function () {
            var self = this;
            self.apartmets = ko.observableArray();

            function downloadApartments(id) {
                apartmentService.getApartmentsByUserId(id).then(function (items) {
                    self.apartmets(items);
                });
            }

           

            self.currentUserId = ko.observable();

            usersService.getCurrentUser().done(function (user) {
                self.currentUserId(user.Id);
            });

            self.currentUserId.subscribe(function (item) {
                downloadApartments(item);
            });

            self.remove = function (item) {
                app.showMessage("Удалить квартиру?", "Удаление квартиры", ["Yes", "No"]).then(function (dialogResult) {
                    if (dialogResult === "Yes") {
                        apartmentService.removeApartment(item.id);
                        downloadApartments(self.currentUserId());
                    }
                });
            }

        }

        

        return new MyApartments();
    });
