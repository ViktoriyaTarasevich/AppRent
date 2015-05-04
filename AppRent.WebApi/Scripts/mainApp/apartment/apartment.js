define([
    'durandal/system', 'durandal/app', 'mainApp/services/apartmentsService', 'knockout', 'jquery', 'gmaps', 'bxslider','sensor'],
    function (system, app, apartmentService, ko,$,GMaps) {

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
                $(element).bxSlider({
                    adaptiveHeight : true
                });
            },
            update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        
            }
        };

        ko.bindingHandlers.maps = {
            init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                var map = new google.maps.Map(
                    document.getElementById('map'), 
                    {
                      zoom: 15,
                      center: new google.maps.LatLng(-12, -77)
                    }
                );
            },
            update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {

            }
        };

        return new apartment();
    });
