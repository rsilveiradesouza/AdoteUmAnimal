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

    $scope.verificarCor = function (animal) {
        //46, 204, 113 - verde para doar
        //230, 126, 34 - laranja para perde
        //'155, 89, 182 - roxo para encontrou

        if (animal.TipoOcorrencia.Sigla == 'DOR') {
            return '46, 204, 113';
        }
        else if (animal.TipoOcorrencia.Sigla == 'ANPD') {
            return '230, 126, 34';
        }
        else if (animal.TipoOcorrencia.Sigla == 'ANEC') {
            return '155, 89, 182';
        }
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
