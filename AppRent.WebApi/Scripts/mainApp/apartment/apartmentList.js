define([
    'durandal/system',
    'durandal/app',
    'mainApp/services/apartmentsService',
    'knockout',
    'mainApp/common/settings'],
    function (system, app,apartmentService,ko,settings) {

        var apartmentList = function () {}
        
        apartmentList.prototype.activate = function () {
            var self = this;

            self.searchTypeForString = settings.searchTypeForString;
            self.searchTypeForNumber = settings.searchTypeForNumber;

            

            self.searchOptions = {
                cityFilter :{ city: ko.observable, comprasionType: ko.observable()} ,
                priceFilter: { price: ko.observable, comprasionType: ko.observable() },
                roomsCountFilter: { roomsCount: ko.observable, comprasionType: ko.observable() }
            }
            self.apartmets = ko.observableArray();

            apartmentService.getApartments().then(function (items) {
                self.apartmets(items);
            });

            self.search = function () {
                apartmentService.getApartments(self.searchOptions).then(function (items) {
                    self.apartmets(items);
                });
            }
        }

        return new apartmentList();
    });
