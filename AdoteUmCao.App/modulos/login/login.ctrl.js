angular.module('app').controller('loginCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Login', '$timeout', '$cordovaFacebook', '$http', function ($scope, $rootScope, $routeParams, Util, $location, Login, $timeout, $cordovaFacebook, $http) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();

        Util.esconderLoading();
    }

    // LOGIN NORMAL

    $scope.loginNormal = function () {
        Util.mostrarLoading();
        Login.loginNormal($scope.username, $scope.password, function (resposta) {
            if (resposta.success) {
                $location.path('/home');
            } else {
                $scope.error = resposta.message;
                Util.esconderLoading();
            }
        });
    };



    // LOGIN FACEBOOK

    $scope.verificarLogin = function () {
        Util.mostrarLoading();

        FB.login(function (retorno) {
            loginCallback(retorno);
        }, { scope: 'public_profile, email', redirect_uri: "http://localhost/callback" });

        //$cordovaOauth.facebook("1573833419609766", ["email", "public_profile"], { redirect_uri: "http://localhost/callback" }).then(function (result) {
        //    displayData($http, result.access_token);
        //}, function (error) {
        //    Util.esconderLoading();
        //    alert("Error: " + error);
        //});

        $cordovaFacebook.login(["public_profile", "email", "user_friends"])
    .then(function (success) {
        console.log(success);
        loginCallback(success);
    }, function (error) {
    });
    }

    function displayData($http, access_token) {
        $http.get("https://graph.facebook.com/v2.2/me", { params: { access_token: access_token, fields: "name,gender,location,picture", format: "json" } }).then(function (result) {
            var name = result.data.name;
            var gender = result.data.gender;
            var picture = result.data.picture;
            Util.esconderLoading();
            console.log(result);
        }, function (error) {
            Util.esconderLoading();
            alert("Error: " + error);
        });
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
        FB.api('/me?fields=id,email,first_name,last_name,picture', function (informacoes) {
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

                $location.path("/");

                Util.esconderLoading();
            })
            .catch(function (erros) {
                Util.mostrarErro(erros);

                console.log(erros);

                Util.esconderLoading();
            });
        });
    }
}]);
