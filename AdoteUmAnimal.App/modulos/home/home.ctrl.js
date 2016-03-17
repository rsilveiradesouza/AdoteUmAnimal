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

    $scope.verPerfil = function (ocorrencia) {
        $rootScope.ocorrenciaAtual = ocorrencia;

        $location.path('/ocorrencia/' + ocorrencia.Id);
    }

    function obterFeed() {
        Ocorrencia.obterOcorrenciasUltimas().then(function (data) {
            $scope.ocorrencias = data.Ocorrencias;

            console.log(data);

            Util.esconderLoading();
        })
        .catch(function (erros) {
            Util.mostrarErro(erros);
            console.log(erros);

            Util.esconderLoading();
        });
    }
}]);
