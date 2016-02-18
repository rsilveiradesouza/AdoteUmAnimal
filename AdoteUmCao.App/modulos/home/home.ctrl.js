angular.module('app').controller('homeCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Cao', function ($scope, $rootScope, $routeParams, Util, $location, Cao) {
    'use strict'

    $scope.iniciar = function () {
        $scope.carregando = true;
        $scope.MensagemHome = "Teste";
        $scope.caes = Cao.obterCaes();

        console.log($scope.caes);
    }
}]);
