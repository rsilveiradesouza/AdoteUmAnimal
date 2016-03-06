angular.module('app').controller('mapaCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Ocorrencia', 'NgMap', '$timeout', function ($scope, $rootScope, $routeParams, Util, $location, Ocorrencia, NgMap, $timeout) {
    'use strict'
    var marcacao = [];

    $scope.iniciar = function () {
        Util.mostrarLoading();
        limparMarcacao();

        var mapInit = $rootScope.$on('mapInitialized', function (evt, map) {
            $scope.map = map;
            $scope.meuLocal = map.getCenter();
            $scope.$apply();

            carregarOcorrencias();

            google.maps.event.clearListeners(map, 'bounds_changed');
            google.maps.event.addListener($scope.map, "bounds_changed", function () {
                if (!$scope.markerClick) {
                    carregarOcorrencias(true);
                }
            });

            mapInit();
        });
    }

    $scope.minhaPosicao = function () {
        $scope.map.panTo($scope.meuLocal);
    }

    function carregarOcorrencias(mudouLugar) {
        if (!mudouLugar) {
            Util.mostrarLoading();
        }

        var bounds = $scope.map.getBounds();
        console.log(bounds);

        if (bounds != null) {
            var swPoint = bounds.getSouthWest();
            var nePoint = bounds.getNorthEast();

            var areaMapa = {
                swLat: swPoint.lat(),
                swLng: swPoint.lng(),
                neLat: nePoint.lat(),
                neLng: nePoint.lng()
            };

            console.log('Area do mapa:', areaMapa);

            Ocorrencia.obterOcorrencias(areaMapa).then(function (data) {
                $scope.ocorrencias = data.Ocorrencias;
                console.log('Ocorrências encontrados:', $scope.ocorrencias);

                popularMapa(data);

                Util.esconderLoading();
            }).catch(function (erros) {
                Util.mostrarErro(erros);
                console.log(erros);

                Util.esconderLoading();
            });
        }
        else {
            Util.mostrarErro(["Não foi possível carregar sua atual posição, tente novamente."]);
            Util.esconderLoading();
        }
    }

    function popularMapa(data) {
        limparMarcacao();

        $scope.Icon = {
            url: 'img/pata.png',
            size: new google.maps.Size(32, 32),
            origin: new google.maps.Point(0, 0),
            anchor: new google.maps.Point(0, 32)
        };

        $scope.Shape = {
            coords: [1, 1, 1, 20, 18, 20, 18, 1],
            type: 'poly'
        };

        var marcas = [];

        for (var i = 0; i < data.Ocorrencias.length; i++) {
            marcas.push({ LatLng: new google.maps.LatLng(parseFloat(data.Ocorrencias[i].Localizacao.Latitude), parseFloat(data.Ocorrencias[i].Localizacao.Longitude)), Endereco: data.Ocorrencias[i].Localizacao.DscEndereco, Nome: data.Ocorrencias[i].Animal.Nome, Descricao: data.Ocorrencias[i].Descricao, Foto: data.Ocorrencias[i].Animal.FotoUrl, Index: (i + 1) });
        }

        for (var i = 0; i < marcas.length; i++) {
            addMarcacao(marcas[i], i * 300);
        }
    }

    function addMarcacao(position, timeout) {
        window.setTimeout(function () {
            var geocoder = new google.maps.Geocoder();

            geocoder.geocode({ 'address': position.Endereco }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    var marker = new google.maps.Marker({
                        position: results[0].geometry.location,
                        icon: $scope.Icon,
                        shape: $scope.Shape,
                        map: $scope.map,
                        draggable: false,
                        animation: google.maps.Animation.DROP,
                        title: position.Nome,
                        zIndex: position.Index,
                        id: position.Index
                    });

                    var infowindow = new google.maps.InfoWindow({
                        content: '<div class="row" style="padding: 5px; margin-bottom: 0; width: 90%;">' +
                                    '<div class="col s12 valign-wrapper">' +
                                        '<div class="valign" style="padding: 2px; border: 1px solid black; border-radius: 5px; display: inline-block;">' +
                                            '<img class="valign" src="' + position.Foto + '" style="width: 50px; height: 50px;">' +
                                        '</div>' +
                                        '<span class="valing" style="margin-left: 5px;">' +
                                            'Nome: ' + position.Nome + '</br>' +
                                            'Descrição: ' + position.Descricao + '</br>' +
                                            'Endereço: ' + position.Endereco +
                                        '</span>' +
                                    '</div>' +
                                 '</div>'
                    });

                    marker.addListener('click', function () {
                        $scope.markerClick = true;

                        window.setTimeout(function () {
                            $scope.markerClick = false;
                        }, 500);

                        infowindow.open($scope.map, marker);
                    });

                    marcacao.push(marker);
                }
            });
        }, timeout);
    }

    function limparMarcacao() {
        for (var i = 0; i < marcacao.length; i++) {
            marcacao[i].setMap(null);
        }

        marcacao = [];
    }
}]);
