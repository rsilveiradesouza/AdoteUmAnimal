angular.module('app').controller('perfilCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Usuario', function ($scope, $rootScope, $routeParams, Util, $location, Usuario) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();
        $rootScope.tituloApp = "Perfil";

        $scope.$watch(function () {
            return $rootScope.usuario;
        }, function () {
            if ($rootScope.usuario != null) {
                obterPerfil();
            }
        }, true);
    }

    function obterPerfil() {
        $scope.usuarioAtual = $rootScope.usuario;

        Util.esconderLoading();
    }
}]);
