angular.module('app').controller('homeCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Ocorrencia', function ($scope, $rootScope, $routeParams, Util, $location, Ocorrencia) {
    'use strict'

    $scope.iniciar = function () {
        Util.mostrarLoading();

        $scope.obterFeed();

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

    $scope.obterFeed = function () {
       
    }
}]);
