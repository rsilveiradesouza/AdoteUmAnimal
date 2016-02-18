angular.module('app').service('Cao', ['$http', '$q', 'Util', function ($http, $q, Util) {
    'use strict'

    return {
        obterCaes: obterCaes
    }

    function obterCaes(areaMapa) {
        var defer = $q.defer();

        $http.get(Util.obterUrlBase() + '/api/home/obterCaes?swLat=' + areaMapa.swLat + '&swLng=' + areaMapa.swLng + '&neLat=' + areaMapa.neLat + '&neLng=' + areaMapa.neLng)
       .success(function (data) {
           if (data != null) {
               if (data.Sucesso) {
                   defer.resolve(data);
               }
               else {
                   defer.reject(data.Mensagens);
               }
           }
           else {
               defer.reject(['Erro ao obter cães']);
           }
       })
       .error(function (data) {
           defer.reject([data]);
       });

        return defer.promise;
    }
}]);