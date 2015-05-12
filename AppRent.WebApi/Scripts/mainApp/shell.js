define(['plugins/router'],
    function (router) {
    return {
        router: router,
        activate: function () {

            router.map([
               { route: '', title: 'Apartments', moduleId: 'mainApp/apartment/apartmentList', nav: true },
               { route: 'apartments/:id', title: 'Apartments', moduleId: 'mainApp/apartment/apartment', nav: true },
               { route: 'newApartment', title: 'New Apartment', moduleId: 'mainApp/apartment/newApartment', nav: true },
               { route: 'myApartments', title: 'My Apartments', moduleId: 'mainApp/apartment/myApartments', nav: true },
               { route: 'adminRoom', title: 'Admin room', moduleId: 'mainApp/adminRoom/adminRoom', nav: true }
            ]).buildNavigationModel();

            return router.activate();
        }
    };
}); 