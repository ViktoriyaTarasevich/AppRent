define([
    'durandal/system', 'durandal/app', 'mainApp/services/apartmentsService', 'knockout'],
    function (system, app, apartmentService, ko) {

        var apartmentList = function () {
            var self = this;
            self.searchTypeForString = [
                { type: '=', id: 0 },
                { type: '!=', id: 1 },
                { type: 'in', id: 2 }
            ];
            self.searchTypeForNumber = [
                { type: '=', id: 0 },
                { type: '!=', id: 1 },
                { type: '<', id: 3 },
                { type: '>', id: 4 }
            ];
        }

      
        return new apartmentList();
    });
