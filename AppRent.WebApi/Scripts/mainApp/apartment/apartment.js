define([
    'durandal/system', 'durandal/app', 'mainApp/services/apartmentsService', 'knockout', 'jquery', 'bxslider'],
    function (system, app, apartmentService, ko,$) {

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

            
        }

        ko.bindingHandlers.imageCarousel = {
            init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                //var options = valueAccessor();
                $(element).bxSlider({
                    adaptiveHeight : true
                });
            },
            update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        
            }
        };


        return new apartment();
    });
