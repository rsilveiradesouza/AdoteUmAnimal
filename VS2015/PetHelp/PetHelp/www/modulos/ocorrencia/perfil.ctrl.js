angular.module('app').controller('ocorrenciaPerfilCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Ocorrencia', function ($scope, $rootScope, $routeParams, Util, $location, Ocorrencia) {
    'use strict'

    $scope.iniciar = function () {
        var id = $routeParams.id;

        Util.mostrarLoading();
        $rootScope.tituloApp = Util.obterAppNome();

        $scope.$watch(function () {
            return $rootScope.usuario;
        }, function () {
            if ($rootScope.usuario != null) {
                obterPerfil(id);
            }
        }, true);
    }

    function obterPerfil(id) {
        console.log($rootScope.ocorrenciaAtual);
        $scope.ocorrencia = $rootScope.ocorrenciaAtual;

        Util.esconderLoading();
    }
}]);
