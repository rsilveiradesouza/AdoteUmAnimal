angular.module('app').service('Login', ['$http', '$q', 'Util', '$timeout', function ($http, $q, Util, $timeout) {
    'use strict'

    return {
        entrarViaFacebook: entrarViaFacebook,
        verificarLogin: verificarLogin,
        loginNormal: loginNormal
    }



    function loginNormal(username, password, callback) {
        /* Apenas teste */
        $timeout(function () {
            var resposta = { success: username === 'teste' && password === 'teste' };
            if (resposta != null) {
                if (!resposta.success) {
                    resposta.message = 'Usuario e senha incorretos';
                }
            }
            callback(resposta);
        }, 1000);

       /** $http.post('/api/login/entrar', { username: username, password: password })
          .success(function (resposta) {
              if (resposta != null) {
                  callback(resposta);
              }
          })
          .error(function (resposta) {
                 if (resposta == null) {
                     resposta = "Algo deu errado! Tente novamente.";
             }
             defer.reject([resposta]);
         }); */
    };


    function entrarViaFacebook(login) {
        var defer = $q.defer();

        $http.post(Util.obterUrlBase() + '/api/login/entrarViaFacebook', login)
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
               defer.reject(['Erro tentar entrar com o facebook.']);
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

    function verificarLogin() {
        var defer = $q.defer();

        var token = localStorage.getItem("usuarioToken");

        $http.defaults.headers.common['Authorization'] = token;

        $http.get(Util.obterUrlBase() + '/api/login/verificarLogin')
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
               defer.reject(['Erro tentar verificar usuario logado.']);
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