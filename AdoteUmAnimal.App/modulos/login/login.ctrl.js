angular.module('app').controller('loginCtrl', function ($scope, $rootScope, $routeParams, Util, $location, Login, $timeout, $http, $log) {
    'use strict'
    var retornoFacebook = {};

    $scope.iniciar = function () {
        Util.mostrarLoading();

        console.log(window.cordova);

        $scope.msgErros = [];
        $scope.usuario = {};

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
        if (window.cordova) {
            facebookConnectPlugin.login(['email', 'public_profile'], loginCallback, fbLoginError);
        }
        else {
            FB.login(loginCallback, { scope: 'email,public_profile' });
        }
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
        retornoFacebook = retorno;

        if (window.cordova) {
            facebookConnectPlugin.api('/me?fields=id,email,first_name,last_name,picture', ["email", "public_profile"], enviarInformacoesFacebook);
        }
        else {
            FB.api('/me?fields=id,email,first_name,last_name,picture', enviarInformacoesFacebook);
        }
    }

    function enviarInformacoesFacebook(informacoes) {
        console.log("Informações Login Facebook", informacoes);

        var loginFacebook = {};
        loginFacebook.Token = retornoFacebook.authResponse.accessToken;
        loginFacebook.UsuarioId = informacoes.id;
        loginFacebook.Nome = informacoes.first_name;
        loginFacebook.Sobrenome = informacoes.last_name;
        loginFacebook.Email = informacoes.email;
        loginFacebook.FotoUrl = informacoes.picture.data.url;

        Login.entrarViaFacebook(loginFacebook).then(function (data) {
            var usuario = data.Usuario;
            localStorage.setItem("usuarioToken", usuario.Token);

            usuario.FotoUrl = Util.obterUrlBase() + '/imagens/perfil/' + usuario.Id + '/perfil.jpg';
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
    }
});
