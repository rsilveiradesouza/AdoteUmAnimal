angular.module('app').controller('homeCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Cao', function ($scope, $rootScope, $routeParams, Util, $location, Cao) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();

        Util.esconderLoading();
        $scope.MensagemHome = "Teste";

        /*Cao.obterCaes().then(function (data) {
            $scope.caes = data.Caes;
            console.log($scope.caes);

            Util.esconderLoading();
        }).catch(function (erros) {
            Util.mostrarErro(erros);
            console.log(erros);

            Util.esconderLoading();
        });*/
    }

    $scope.mostrarMapa = function () {

    }
}]);
