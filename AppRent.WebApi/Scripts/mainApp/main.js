requirejs.config({
    baseUrl: "Scripts",
    paths: {
        'text': 'text',
        'durandal': 'durandal',
        'plugins': 'durandal/plugins',
        'transitions': 'durandal/transitions',
        'knockout': 'knockout-3.1.0',
        'jquery': 'jquery-1.10.2',
        'bootstrap': 'bootstrap',
        'lodash': 'lodash',
        'bxslider': 'jquery.bxslider',
        'gmaps': 'gmaps',
        'sensor': 'sensor'
    }
});

define(['durandal/system', 'durandal/app'],
    function (system,app) {

    system.debug(true);

    app.title = 'Apartment Rent App';

    app.configurePlugins({
        router: true,
        dialog: true
    });

    app.start().then(function () {
        app.setRoot('mainApp/shell');
    });
});