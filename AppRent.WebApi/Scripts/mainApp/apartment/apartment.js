define([
    'durandal/system', 'durandal/app', 'mainApp/services/apartmentsService', 'knockout'],
    function (system, app, apartmentService, ko) {

        var apartment = function () {
            
        }

        apartment.prototype.activate = function (id) {
            var self = this;
            self.id = id;
            self.apartment = ko.observable();

            apartmentService.getApartmentById(self.id).then(function (item) {
                self.apartment(item);
            });
        }

        return new apartment();
    });
