define(['durandal/system', 'durandal/app', 'jquery'],
    function (system, app, $) {

        var UsersService = function () {
            var self = this;
            var url = '../api/User/';

            self.getCurrentUser = function () {
                return $.ajax({
                    method: 'GET',
                    url: '../Home/CurrentUser',
                });
            }

            

        }

        return new UsersService;
    });
