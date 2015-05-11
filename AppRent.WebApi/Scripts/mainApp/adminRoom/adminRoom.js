define([
    'durandal/system',
    'durandal/app',
    'mainApp/services/apartmentsService',
    'knockout',
    'jquery',
    'mainApp/services/usersService'],
    function (system, app, apartmentService, ko, $, usersService) {

        var AdminRoom = function () {
            this.selectedApartment = ko.observable();
        }

        AdminRoom.prototype.activate = function () {
            var self = this;
            self.users = ko.observableArray();
            

            self.currentUser = ko.observable();

            usersService.getCurrentUser().done(function (user) {
                self.currentUser(user);
            });

            self.currentUser.subscribe(function (item) {
                if (item.Role.Id == 3) {
                    downloadUsers();
                }
            });

            function downloadUsers() {
                self.users.removeAll();
                usersService.getUsers().then(function (users) {
                    self.users(users);
                });
            }

            self.removeUser = function (item) {
                
                app.showMessage("Удалить юзера?", "Удаление юзера", ["Yes", "No"]).then(function (dialogResult) {
                    if (dialogResult === "Yes") {
                        usersService.remove(item.id);
                        self.users.remove(item);
                    }
                });

            }

            self.removeApartment = function (item) {
                app.showMessage("Удалить квартиру?", "Удаление квартиры", ["Yes", "No"]).then(function (dialogResult) {
                    if (dialogResult === "Yes") {
                        apartmentService.remove(item.id);
                        downloadUsers();
                    }
                });
                
            }

            self.setAdmin = function (item) {
                usersService.setAdmin(item.id);
                downloadUsers();
            }

            self.setUser = function (item) {
                usersService.setUser(item.id);
                downloadUsers();
            }

            self.setHomeowner = function (item) {
                usersService.setHomeowner(item.id);
            }

        }



        return new AdminRoom();
    });
