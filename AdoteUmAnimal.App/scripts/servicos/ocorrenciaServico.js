angular.module('app').service('Ocorrencia', ['$http', '$q', 'Util', '$location', function ($http, $q, Util, $location) {
    'use strict'

    return {
        obterOcorrencias: obterOcorrencias,
        obterOcorrenciasUltimas: obterOcorrenciasUltimas
    }

    function obterOcorrencias(areaMapa) {
        var defer = $q.defer();

        var token = localStorage.getItem("usuarioToken");

        $http.defaults.headers.common['Authorization'] = token;

        $http.get(Util.obterUrlBase() + '/api/home/obterOcorrencias?swLat=' + areaMapa.swLat + '&swLng=' + areaMapa.swLng + '&neLat=' + areaMapa.neLat + '&neLng=' + areaMapa.neLng)
       .success(function (data) {
           if (data != null) {
               if (data.Sucesso) {
                   defer.resolve(data);
               }
               else {
                   if (!data.Autorizado) {
                       $location.path('/login');
                   }
                   else {
                       defer.reject(data.Mensagens);
                   }
               }
           }
           else {
               defer.reject(['Erro ao obter as ocorrências']);
           }
       })
       .error(function (data) {
           if (data == null) {
               data = "Algo deu errado! Tente novamente.";
           }

           defer.reject([data]);
       });

        return defer.promise;
    }

    function obterOcorrenciasUltimas() {
        var defer = $q.defer();

        var token = localStorage.getItem("usuarioToken");

        $http.defaults.headers.common['Authorization'] = token;

        $http.get(Util.obterUrlBase() + '/api/home/obterOcorrenciasUltimas')
       .success(function (data) {
           if (data != null) {
               if (data.Sucesso) {
                   defer.resolve(data);
               }
               else {
                   if (!data.Autorizado) {
                       $location.path('/login');
                   }
                   else {
                       defer.reject(data.Mensagens);
                   }
               }
           }
           else {
               defer.reject(['Erro ao obter as ocorrências']);
           }
       })
       .error(function (data) {
           if (data == null) {
               data = "Algo deu errado! Tente novamente.";
           }

           defer.reject([data]);
       });

        return defer.promise;
    }
}]);