angular.module('app').controller('finalizarCadastroCtrl', function ($scope, $rootScope, $routeParams, Util, $location, Login, $timeout, $http) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();

        $scope.usuario = $rootScope.usuario;

        Util.esconderLoading();
    }
    
    $scope.salvar = function () {
        Util.mostrarLoading();
        if ($scope.validarTamanhoSenha() && $scope.validarPreenchimento() && $scope.compararSenhas() && $scope.validarEmail()) {
            Login.salvarFinalizacaoCadastro($scope.usuario).then(function (data) {
                Util.esconderLoading();
                $rootScope.usuario = data.Usuario;

                $location.path("/");
            }).catch(function (erros) {
                Util.mostrarErro(erros);

                console.log(erros);

                Util.esconderLoading();
            });
        } else {
            Util.esconderLoading();
        }
    }

    $scope.validarTamanhoSenha = function(){
        if(null != $scope.usuario.Senha || $scope.usuario.Senha != ""){
            if ($scope.usuario.Senha.length > 5) {
                return true;
            }else{
                return false;
            }
        }
    }

    $scope.compararSenhas = function () {
        if((null != $scope.usuario.Senha || $scope.usuario.Senha != "")
        && (null != $scope.usuario.ConfirmaSenha || $scope.usuario.ConfirmaSenha != "")) {
            if ($scope.usuario.Senha == $scope.usuario.ConfirmaSenha) {
                return true;
            } else {
                return false;
            }
        }
    }

    $scope.validarEmail = function () {
        if(null != $scope.usuario.Email){
            var email = $scope.usuario.Email;
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (email == '' || !re.test(email)) {
                return false;
            } else {
                return true;
            }   
        } else {
            return false;
        }
    }

    $scope.validarPreenchimento = function () {
        if ((null != $scope.usuario.Celular || $scope.usuario.Celular != "") 
        && (null != $scope.usuario.Senha || $scope.usuario.Senha != "")
        && (null != $scope.usuario.ConfirmaSenha || $scope.usuario.ConfirmaSenha != "")) {
            return true;
        } else {
            return false;
        }
    }
});
