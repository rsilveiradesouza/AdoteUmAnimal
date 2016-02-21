angular.module('app', ['ngRoute', 'ngAnimate', 'ngCookies', 'ngSanitize', 'ngLocale', 'ngMap'])
    .config(function ($routeProvider, $httpProvider) {
        $httpProvider.interceptors.push('timeoutHttpIntercept');

        $routeProvider.when('/home', {
            controller: 'homeCtrl',
            templateUrl: 'modulos/home/home.html'
        })
        .when('/login', {
            controller: 'loginCtrl',
            templateUrl: 'modulos/login/login.html'
        })
        .when('/mapa', {
            controller: 'mapaCtrl',
            templateUrl: 'modulos/mapa/mapa.html'
        })
        .otherwise({ redirectTo: '/home' });
    })
    .factory('timeoutHttpIntercept', function ($rootScope, $q) {
        return {
            'request': function (config) {
                config.timeout = 5000;
                return config;
            }
        };
    });