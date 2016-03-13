angular.module('app').controller('homeCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Ocorrencia', function ($scope, $rootScope, $routeParams, Util, $location, Ocorrencia) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();
        $rootScope.tituloApp = Util.obterAppNome();

        $scope.$watch(function () {
            return $rootScope.usuario;
        }, function () {
            if ($rootScope.usuario != null) {
                obterFeed();
            }
        }, true);
    }

    function obterFeed() {
        Util.esconderLoading();
    }
}]);
