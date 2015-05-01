define([
    'durandal/system', 'durandal/app', 'mainApp/services/apartmentsService', 'knockout'],
    function (system, app,apartmentService,ko) {

        var apartmentList = function () {}

        apartmentList.prototype.activate = function () {
            var self = this;
            self.apartmets = ko.observableArray();

            apartmentService.getApartments().then(function (items) {
                self.apartmets(items);
            });
        }

        return new apartmentList();
    });
