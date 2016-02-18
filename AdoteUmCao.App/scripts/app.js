angular.module('app', ['ngRoute', 'ngAnimate', 'ngCookies', 'ngSanitize', 'ngLocale', 'ngMap'])
    .config(function ($routeProvider) {

        $routeProvider.when('/home', {
            controller: 'homeCtrl',
            templateUrl: 'modulos/home/home.html'
        })
        .when('/mapa', {
            controller: 'mapaCtrl',
            templateUrl: 'modulos/mapa/mapa.html'
        })
        .otherwise({ redirectTo: '/home' });
    });