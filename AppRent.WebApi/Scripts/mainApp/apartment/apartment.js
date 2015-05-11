define([
    'durandal/system', 'durandal/app', 'mainApp/services/apartmentsService', 'knockout', 'jquery', 'bxslider', 'mainApp/services/usersService'],
    function (system, app, apartmentService, ko, $,slider, usersService) {

        var apartment = function () {
            
        }

        apartment.prototype.activate = function (id) {
            var self = this;
            self.id = id;
            self.apartment = ko.observable(); 

            apartmentService.getApartmentById(self.id).then(function (item) {
                self.apartment(item);
            });
            self.carouselOptions = ko.observable();

            self.currentUserId = ko.observable();

            usersService.getCurrentUser().done(function (user) {
                self.currentUserId(user.Id);
            });

            self.isMyApartment = ko.computed(function () {
                if (typeof self.currentUserId() != "undefined" && typeof self.apartment() != "undefined") {
                    if (self.currentUserId() === self.apartment().user.id) {
                        return true;
                    }
                }
                
                return false;
            }, self);

            self.save = function (item) {
                apartmentService.updateApartment(item.id,{
                    price: item.price,
                    roomsCount: item.roomsCount,
                    description: item.description
                }).then(function () {
                    app.showMessage('Информация обновлена!');
                });
            }
        }

        ko.bindingHandlers.imageCarousel = {
            init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                $(element).bxSlider({
                    adaptiveHeight : true
                });
            },
            update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        
            }
        };

        

        return new apartment();
    });
