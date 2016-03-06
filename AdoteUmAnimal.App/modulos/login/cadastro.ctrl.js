angular.module('app').controller('cadastroCtrl', function ($scope, $rootScope, $routeParams, Util, $location, Login, $timeout, $http) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();

        $scope.msgErros = [];

        $scope.usuario = {};

        Util.esconderLoading();
    }

    $scope.salvar = function () {
        Util.mostrarLoading();

        if ($scope.validarPreenchimento() && $scope.validarTamanhoSenha() & $scope.compararSenhas() & $scope.validarEmail()) {
            Login.cadastrarUsuario($scope.usuario).then(function (data) {
                Util.esconderLoading();
                var usuario = data.Usuario;

                localStorage.setItem("usuarioToken", usuario.Token);

                $rootScope.usuario = usuario;

                console.log("Usuario Logado: ", usuario);

                $location.path("/");
            }).catch(function (erros) {
                Util.mostrarErro(erros);

                console.log(erros);

                Util.esconderLoading();
            });
        } else {
            Util.mostrarErro($scope.msgErros);
            $scope.msgErros = [];
            Util.esconderLoading();
        }
    }

    $scope.validarTamanhoSenha = function () {
        if (null != $scope.usuario.Senha && $scope.usuario.Senha != "") {
            if ($scope.usuario.Senha.length > 5) {
                return true;
            } else {
                $scope.msgErros.push("Senha tem que ser maior ou igual a 6 caracteres.");
                return false;
            }
        }
        else {
            $scope.msgErros.push("Nenhuma senha digitada.");

            return false;
        }
    }

    $scope.compararSenhas = function () {
        if ((null != $scope.usuario.Senha && $scope.usuario.Senha != "")
        && (null != $scope.usuario.ConfirmaSenha && $scope.usuario.ConfirmaSenha != "")) {
            if ($scope.usuario.Senha == $scope.usuario.ConfirmaSenha) {
                return true;
            } else {
                $scope.msgErros.push("Verifique a senha digitada.");
                return false;
            }
        }
        else {
            $scope.msgErros.push("Digite uma senha.");
            return false;
        }
    }

    $scope.validarEmail = function () {
        if (null != $scope.usuario.Email) {
            var email = $scope.usuario.Email;
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (email == '' || !re.test(email)) {
                $scope.msgErros.push("Verifique o email digitado.");

                return false;
            } else {
                return true;
            }
        } else {
            $scope.msgErros.push("Nenhum email digitado.");
            return false;
        }
    }

    $scope.validarPreenchimento = function () {
        if ((null != $scope.usuario.Celular && $scope.usuario.Celular != "")
        && (null != $scope.usuario.Senha && $scope.usuario.Senha != "")
        && (null != $scope.usuario.ConfirmaSenha && $scope.usuario.ConfirmaSenha != "")
        && ($scope.usuario.Nome != null && $scope.usuario.Nome != "")
        && ($scope.usuario.Sobrenome != null && $scope.usuario.Sobrenome != "")
        && ($scope.usuario.Email != null && $scope.usuario.Email != "")) {
            return true;
        } else {
            $scope.msgErros.push("Preencha todos os campos.");

            return false;
        }
    }
});
