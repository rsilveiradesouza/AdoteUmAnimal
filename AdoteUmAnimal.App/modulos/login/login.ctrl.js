angular.module('app').controller('loginCtrl', function ($scope, $rootScope, $routeParams, Util, $location, Login, $timeout, $http) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();

        $scope.msgErros = [];
        $scope.usuario = {};

        if (window.cordova && window.cordova.platformId == "browser") {
            facebookConnectPlugin.browserInit("1573833419609766", "v2.5");
        }

        Util.esconderLoading();
    }

    $scope.logar = function () {
        Util.mostrarLoading();

        if ($scope.validarPreenchimento()) {
            Login.logar($scope.usuario.Email, $scope.usuario.Senha).then(function (data) {
                var usuario = data.Usuario;
                localStorage.setItem("usuarioToken", usuario.Token);

                $rootScope.usuario = usuario;

                console.log("Usuario Logado: ", usuario);

                $location.path("/");

                Util.esconderLoading();
            }).catch(function (erros) {
                Util.mostrarErro(erros);

                console.log(erros);

                Util.esconderLoading();
            });
        }
        else {
            Util.mostrarErro($scope.msgErros);
            $scope.msgErros = [];
            Util.esconderLoading();
        }
    };

    $scope.validarPreenchimento = function () {
        if ((null != $scope.usuario.Email && $scope.usuario.Email != "")
        && (null != $scope.usuario.Senha && $scope.usuario.Senha != "")) {
            return true;
        } else {
            $scope.msgErros.push("Preencha todos os campos.");

            return false;
        }
    }

    $scope.verificarLogin = function () {
        facebookConnectPlugin.login(['email', 'public_profile'], loginCallback, fbLoginError);
    }

    function fbLoginError(retorno) {
        console.log('fbLoginError', retorno);
        Util.esconderLoading();
    }

    function loginCallback(retorno) {
        console.log(retorno);

        if (retorno.status === 'connected') {
            //login aprovado
            obterInformacoesUsuarioFacebook(retorno);
        } else if (retorno.status === 'not_authorized') {
            //não autorizado a logar
            Util.esconderLoading();
        } else {
            //usuário não logado no facebook
            Util.esconderLoading();
        }
    }

    function obterInformacoesUsuarioFacebook(retorno) {
        facebookConnectPlugin.api('/me?fields=id,email,first_name,last_name,picture', ["email","public_profile"], function (informacoes) {
            console.log("Informações Login Facebook", informacoes);

            var loginFacebook = {};
            loginFacebook.Token = retorno.authResponse.accessToken;
            loginFacebook.UsuarioId = informacoes.id;
            loginFacebook.Nome = informacoes.first_name;
            loginFacebook.Sobrenome = informacoes.last_name;
            loginFacebook.Email = informacoes.email;

            Login.entrarViaFacebook(loginFacebook).then(function (data) {
                var usuario = data.Usuario;
                localStorage.setItem("usuarioToken", usuario.Token);

                $rootScope.usuario = usuario;

                console.log("Usuario Logado: ", usuario);

                if (usuario.Celular == null) {
                    $location.path("/login/finalizarCadastro");
                }
                else {
                    $location.path("/");
                }

                Util.esconderLoading();
            })
            .catch(function (erros) {
                Util.mostrarErro(erros);

                console.log(erros);

                Util.esconderLoading();
            });
        });
    }
});
