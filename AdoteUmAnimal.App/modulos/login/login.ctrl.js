angular.module('app').controller('loginCtrl', function ($scope, $rootScope, $routeParams, Util, $location, Login, $timeout, $http) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();

        $scope.usuario = {};

        Util.esconderLoading();
    }

    $scope.logar = function () {
        Util.mostrarLoading();

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
    };

    $scope.verificarLogin = function () {
        Util.mostrarLoading();

        openFB.login(loginCallback, { scope: 'email,public_profile' });

        //FB.login(function (retorno) {
        //    loginCallback(retorno);
        //}, { scope: 'public_profile, email', redirect_uri: "https://www.facebook.com/connect/login_success.html" });
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
        //FB.api('/me?fields=id,email,first_name,last_name,picture', function (informacoes) {
        openFB.info(function (informacoes) {
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
