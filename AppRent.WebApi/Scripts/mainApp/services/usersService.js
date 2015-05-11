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

            self.getUsers = function () {
                return $.ajax({
                    method: 'GET',
                    url: url
                });
            }

            self.remove = function (id) {
                return $.ajax({
                    method: 'DELETE',
                    url: url + id
                });
            }

            self.setAdmin = function (id) {
                return $.ajax({
                    method: 'GET',
                    url: '../Home/ChangerRoleToAdmin/'+id
                  
                });
            }

            self.setUser = function (id) {
                return $.ajax({
                    method: 'GET',
                    url: '../Home/ChangerRoleToUser/'+id
                   
                });
            }
            
        }

        return new UsersService;
    });
