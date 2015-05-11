define([
    'durandal/system',
    'durandal/app',
    'mainApp/services/apartmentsService',
    'knockout',
    'mainApp/common/settings',
    'mainApp/services/usersService'],
    function (system, app,apartmentService,ko,settings,usersService) {

        var apartmentList = function () {}
        
        apartmentList.prototype.activate = function () {
            var self = this;

            self.searchTypeForString = settings.searchTypeForString;
            self.searchTypeForNumber = settings.searchTypeForNumber;

            self.isHomeowner = ko.observable(false);
            self.isUser = ko.observable(false);
            self.isAdmin = ko.observable(false);
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

            usersService.getCurrentUser().done(function (user) {
                if (user) {
                    if (user.Role.Id == 1) {
                        self.isUser(true);
                    } 
                    if (user.Role.Id == 2) {
                        self.isHomeowner(true);
                    }
                    if (user.Role.Id == 3) {
                        self.isAdmin(true);
                    }
                }
            });
        }

        return new apartmentList();
    });
