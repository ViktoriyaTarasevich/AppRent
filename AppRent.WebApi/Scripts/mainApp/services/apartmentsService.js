define(['durandal/system', 'durandal/app','jquery'],
    function (system, app,$) {

        var ApartementsService = function () {
            var self = this;
            var url = '../api/Apartment/';

            self.getApartments = function (requestData) {
                return $.ajax({
                    method: 'GET',
                    url: url,
                    data: requestData 
                });
            }

            self.getApartmentById = function (id) {
                return $.ajax({
                    method: 'GET',
                    url: url + id,
                });
            }

            self.getApartmentsByUserId = function (userId) {
                return $.ajax({
                    method: 'GET',
                    url: url + 'GetApartmentsByUserId/'+userId
                });
            }

            self.saveApartment = function (requestData) {
                return $.ajax({
                    method: 'POST',
                    url: url,
                    data: requestData
                });
            }

            

            self.updateApartment = function (id, requestData) {
                return $.ajax({
                    method: 'PUT',
                    url: url + id,
                    data: requestData
                });
            }

            self.removeApartment = function (id) {
                return $.ajax({
                    method: 'DELETE',
                    url: url + id
                });
            }

        }

        return new ApartementsService;
    });
