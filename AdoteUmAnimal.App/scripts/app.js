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
        $routeProvider.when('/ocorrencia/:id', {
            controller: 'ocorrenciaPerfilCtrl',
            templateUrl: 'modulos/ocorrencia/perfil.html'
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
        .when('/perfil', {
            controller: 'perfilCtrl',
            templateUrl: 'modulos/usuario/perfil.html'
        })
        .when('/mapa', {
            controller: 'mapaCtrl',
            templateUrl: 'modulos/mapa/mapa.html'
        })
        .otherwise({ redirectTo: '/home' });
    })
    .controller('mainCtrl', function ($rootScope, $q, $scope, $location, Util, Login) {
        $rootScope.tituloApp = Util.obterAppNome();
        $rootScope.versaoApp = Util.obterVersaoApp();
        $rootScope.tamanhoTopo = 56;

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

        $scope.irHome = function () {
            $location.path('/home');
            $scope.paginaSelecionada = 1;
        }

        $scope.irBusca = function () {
            $location.path('/buscar');
            $scope.paginaSelecionada = 2;
        }

        $scope.irMapa = function () {
            $location.path('/mapa');
            $scope.paginaSelecionada = 3;
        }

        $scope.irPerfil = function () {
            $location.path('/perfil');
            $scope.paginaSelecionada = 4;
        }

        if (!$rootScope.Desenvolvimento) {
            $rootScope.$on('$locationChangeStart', function (event) {
                if ($location.$$path.indexOf("/home") != -1) {
                    $scope.paginaSelecionada = 1;
                }
                else if ($location.$$path.indexOf("/busca") != -1) {
                    $scope.paginaSelecionada = 2;
                }
                else if ($location.$$path.indexOf("/mapa") != -1) {
                    $scope.paginaSelecionada = 3;
                }
                else if ($location.$$path.indexOf("/perfil") != -1) {
                    $scope.paginaSelecionada = 4;
                }

                if ($rootScope.usuario == null) {
                    if ($location.$$path.indexOf("/login") == -1) {
                        console.log("login", $location);
                        var token = localStorage.getItem("usuarioToken");

                        if (!$rootScope.verificandoLogin) {
                            if (token != null) {
                                $rootScope.verificandoLogin = true;

                                Login.verificarLogin().then(function (data) {
                                    $rootScope.verificandoLogin = false;
                                    var usuario = data.Usuario;
                                    localStorage.setItem("usuarioToken", usuario.Token);

                                    usuario.FotoUrl = Util.obterUrlBase() + '/imagens/perfil/' + usuario.Id + '/perfil.jpg';

                                    $rootScope.usuario = usuario;

                                    if (usuario.Celular == null) {
                                        if ($location.$$path.indexOf("/login/finalizarCadastro") == -1) {
                                            $location.path("/login/finalizarCadastro");
                                            console.log("finalizar");
                                            event.preventDefault();
                                        }
                                    }
                                }).catch(function (data) {
                                    $rootScope.verificandoLogin = false;

                                    Util.mostrarErro(data);
                                    $location.path("/login");

                                    event.preventDefault();
                                });
                            }
                            else {
                                $location.path("/login");
                            }
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