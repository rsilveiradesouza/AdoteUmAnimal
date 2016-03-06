angular.module('app', ['ngRoute', 'ngAnimate', 'ngCookies', 'ngSanitize', 'ngLocale', 'ngMap'])
    .run(function () {
        openFB.init({ appId: '1573833419609766' });
    })
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
        .when('/login/finalizarCadastro', {
            controller: 'finalizarCadastroCtrl',
            templateUrl: 'modulos/login/finalizarCadastro.html'
        })
        .when('/login/cadastro', {
            controller: 'cadastroCtrl',
            templateUrl: 'modulos/login/cadastro.html'
        })
        .when('/mapa', {
            controller: 'mapaCtrl',
            templateUrl: 'modulos/mapa/mapa.html'
        })
        .otherwise({ redirectTo: '/home' });
    })
    .controller('mainCtrl', function ($rootScope, $q, $scope, $location, Util, Login) {
        $rootScope.Desenvolvimento = false;
        $(".button-collapse").sideNav({ closeOnClick: true });

        $scope.deslogar = function () {
            localStorage.clear();
            $rootScope.usuario = null;
            $location.path('/login');
        }

        $scope.verificarTelaLogin = function () {
            if ($location.$$path.indexOf('login') == -1) {
                return false;
            }

            return true;
        }

        if (!$rootScope.Desenvolvimento) {
            $rootScope.$on('$locationChangeStart', function (event) {
                if ($rootScope.usuario == null) {
                    if ($location.$$path.indexOf("login") == -1) {
                        var token = localStorage.getItem("usuarioToken");

                        if (token != null) {
                            Login.verificarLogin().then(function (data) {
                                var usuario = data.Usuario;
                                localStorage.setItem("usuarioToken", usuario.Token);

                                $rootScope.usuario = usuario;

                                if (usuario.Celular == null) {
                                    if ($location.$$path.indexOf("/login/finalizarCadastro") == -1) {
                                        $location.path("/login/finalizarCadastro");
                                        console.log("finalizar");
                                        event.preventDefault();
                                    }
                                }
                            }).catch(function (data) {
                                Util.mostrarErro(data);
                                $location.path("/login");

                                event.preventDefault();
                            });
                        }
                        else {
                            $location.path("/login");
                        }

                        return;
                    }
                }
            });
        }
    })
    .factory('timeoutHttpIntercept', function ($rootScope, $q) {
        return {
            'request': function (config) {
                config.timeout = 30000;
                return config;
            }
        };
    });