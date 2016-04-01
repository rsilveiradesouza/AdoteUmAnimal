angular.module('app', ['ngRoute', 'ngAnimate', 'ngCookies', 'ngSanitize', 'ngLocale', 'ngMap', 'pubnub.angular.service'])
    .run(['Pubnub', function (Pubnub) {
        openFB.init({ appId: '1573833419609766' });

        Pubnub.init({
            subscribe_key: 'sub-c-462d930c-f36c-11e5-8679-02ee2ddab7fe',
            publish_key: 'pub-c-d522b684-ab63-4a27-aed3-c5dde8250681',
        });
    }])
    .config(function ($routeProvider, $httpProvider) {
        $httpProvider.interceptors.push('timeoutHttpIntercept');

        $routeProvider.when('/home', {
            controller: 'homeCtrl',
            templateUrl: 'modulos/home/home.html'
        })
        $routeProvider.when('/teste', {
            controller: 'testeCtrl',
            templateUrl: 'modulos/teste/teste.html'
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
    .controller('mainCtrl', function ($rootScope, $q, $scope, $location, Util, Login, Pubnub) {
        $rootScope.tituloApp = Util.obterAppNome();
        $rootScope.versaoApp = Util.obterVersaoApp();
        $rootScope.tamanhoTopo = Util.tamanhoTopo();

        $rootScope.Desenvolvimento = false;
        $(".button-collapse").sideNav({ closeOnClick: true });

        $scope.verificarIOS = function () {
            if (isMobile.iOS()) {
                return 7;
            }

            return 0;
        };

        $scope.deslogar = function () {
            localStorage.clear();
            $rootScope.usuario = null;
            $location.path('/login');
        }

        $scope.verificarTela = function () {
            if ($location.$$path.indexOf('login') == -1 && $location.$$path.indexOf('teste') == -1) {
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

        var isMobile = {
            Windows: function () {
                return /IEMobile/i.test(navigator.userAgent);
            },
            Android: function () {
                return /Android/i.test(navigator.userAgent);
            },
            BlackBerry: function () {
                return /BlackBerry/i.test(navigator.userAgent);
            },
            iOS: function () {
                return /iPhone|iPad|iPod/i.test(navigator.userAgent);
            },
            any: function () {
                return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Windows());
            }
        };

        if (!$rootScope.Desenvolvimento) {
            $rootScope.$on('$locationChangeStart', function (event) {
                $rootScope.tamanhoTopo = Util.tamanhoTopo();

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
                    if ($location.$$path.indexOf("/login") == -1 && $location.$$path.indexOf("/teste") == -1) {
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