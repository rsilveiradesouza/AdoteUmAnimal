angular.module('app').service('Login', ['$http', '$q', 'Util', function ($http, $q, Util) {
    'use strict'

    return {
        entrarViaFacebook: entrarViaFacebook,
        verificarLogin: verificarLogin,
        salvarFinalizacaoCadastro: salvarFinalizacaoCadastro,
        cadastrarUsuario: cadastrarUsuario,
        logar: logar
    }

    function cadastrarUsuario(usuario) {
        var defer = $q.defer();

        $http.post(Util.obterUrlBase() + '/api/login/cadastrarUsuario', usuario)
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
                   defer.reject(['Erro tentar cadastrar usuário.']);
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

    function salvarFinalizacaoCadastro(usuario) {
        var defer = $q.defer();

        var token = localStorage.getItem("usuarioToken");

        $http.defaults.headers.common['Authorization'] = token;

        $http.post(Util.obterUrlBase() + '/api/login/finalizarCadastro', usuario)
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
                   defer.reject(['Erro tentar finalizar cadastro.']);
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

    function logar(usuario, senha) {
        var defer = $q.defer();

        $http.get(Util.obterUrlBase() + '/api/login/logar?usuario=' + usuario + '&senha=' + senha)
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
                   defer.reject(['Erro tentar logar.']);
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