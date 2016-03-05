angular.module('app').controller('finalizarCadastroCtrl', function ($scope, $rootScope, $routeParams, Util, $location, Login, $timeout, $http) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();

        $scope.usuario = $rootScope.usuario;

        Util.esconderLoading();
    }

    $scope.salvar = function () {
        Login.salvarFinalizacaoCadastro($scope.usuario);
    }
});
