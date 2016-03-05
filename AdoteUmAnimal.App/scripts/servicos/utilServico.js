angular.module('app').service('Util', ['$http', function ($http) {
    'use strict'

    return {
        obterArrayPaginas: obterArrayPaginas,
        mostrarErro: mostrarErro,
        mostrarSucesso: mostrarSucesso,
        obterUrlBase: obterUrlBase,
        mostrarLoading: mostrarLoading,
        esconderLoading: esconderLoading
    }

    function mostrarLoading() {
        document.getElementById("fullscreen_panel").style.display = "block";
        document.getElementById("div_wait").style.display = "block";
    }

    function esconderLoading() {
        document.getElementById("fullscreen_panel").style.display = "none";
        document.getElementById("div_wait").style.display = "none";
    }

    function obterUrlBase() {
        //return 'http://localhost:65303';
        return 'http://192.168.0.103:9998';
    }

    function obterArrayPaginas(paginaAtual, totalPaginas) {
        var array = [];
        var limiteLinhas = 11;
        var totalPaginasTras = 0;
        var primeiroAtras = 0;

        for (var i = paginaAtual - 5; i < paginaAtual; i++) {
            if (i > 0 && i <= totalPaginas) {
                array.push(i);
                totalPaginasTras++;
                if (i == paginaAtual - 5) {
                    primeiroAtras = i;
                }
            }
        }

        for (var i = paginaAtual; i < paginaAtual + (limiteLinhas - totalPaginasTras) ; i++) {
            if (i <= totalPaginas) {
                array.push(i);
            }
        }

        if (array.length < limiteLinhas) {
            while (array.length < limiteLinhas && totalPaginas > array.length) {
                primeiroAtras = primeiroAtras - 1;
                array.push(primeiroAtras);
            }
        }

        return array;
    }

    function mostrarSucesso(message) {
        alertify.success(message);
    }

    function mostrarErro(messages) {
        var msg = '';
        for (var i = 0; i < messages.length; i++) {
            if (i == 0)
                msg += messages[i];
            else {
                msg += '<p>' + messages[i] + '</p>';
            }
        }
        alertify.error(msg);
    }
}]);