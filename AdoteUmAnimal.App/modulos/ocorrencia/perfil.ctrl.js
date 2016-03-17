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

        //Ocorrencia.obterOcorrencia(id).then(function (data) {
        //    $scope.ocorrencias = data.Ocorrencias;

        //    console.log(data);

        //    Util.esconderLoading();
        //})
        //.catch(function (erros) {
        //    Util.mostrarErro(erros);
        //    console.log(erros);

        //    Util.esconderLoading();
        //});
    }
}]);
