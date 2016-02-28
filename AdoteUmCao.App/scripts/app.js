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
        .when('/loginNormal', {
            controller: 'loginCtrl',
            templateUrl: 'modulos/login/loginNormal.html'
        })
        .when('/mapa', {
            controller: 'mapaCtrl',
            templateUrl: 'modulos/mapa/mapa.html'
        })
        .otherwise({ redirectTo: '/home' });
    })
    .controller('mainCtrl', function ($rootScope, $q, $scope, $location, Util, Login) {
        //$rootScope.$on('$locationChangeStart', function (event) {
        //    if ($rootScope.usuario == null) {
        //        if ($location.$$path.indexOf("login") == -1) {
        //            Login.verificarLogin().then(function (data) {
        //                var usuario = data.Usuario;
        //                localStorage.setItem("usuarioToken", usuario.Token);

        //                $rootScope.usuario = usuario;

        //                if (usuario.Celular == "") {
        //                    if ($location.$$path.indexOf("/cadastro/redesocial") == -1) {
        //                        $location.path("/cadastro/redesocial");
        //                        event.preventDefault();
        //                    }
        //                }
        //            }).catch(function (data) {
        //                Util.mostrarErro(data);
        //                $location.path("/login");

        //                event.preventDefault();
        //            });

        //            return;
        //        }
        //    }
        //    else {
        //        if ($location.$$path.indexOf("/cadastro/redesocial") == -1) {
        //            if ($rootScope.usuario.Celular == "") {
        //                $location.path("/cadastro/redesocial");
        //                event.preventDefault();
        //            }
        //        }
        //    }
        //});
    })
    .factory('timeoutHttpIntercept', function ($rootScope, $q) {
        return {
            'request': function (config) {
                config.timeout = 10000;
                return config;
            }
        };
    });