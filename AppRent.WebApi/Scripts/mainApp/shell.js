define(['plugins/router'],
    function (router) {
    return {
        router: router,
        activate: function () {

            router.map([
               { route: '', title: 'Apartments', moduleId: 'mainApp/apartment/apartmentList', nav: true },
               { route: 'apartments/:id', title: 'Apartments', moduleId: 'mainApp/apartment/apartment', nav: true }

            ]).buildNavigationModel();

            return router.activate();
        }
    };
});