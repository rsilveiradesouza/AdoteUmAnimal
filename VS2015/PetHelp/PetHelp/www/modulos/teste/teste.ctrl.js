angular.module('app').controller('testeCtrl', ['$scope', '$rootScope', '$routeParams', 'Util', '$location', 'Pubnub', function ($scope, $rootScope, $routeParams, Util, $location, Pubnub) {
    'use strict'

    $scope.iniciar = function () {
        $rootScope.tituloApp = "Teste";

        $rootScope.$on(Pubnub.getEventNameFor('publish', 'callback'), function (ngEvent, message) {
            console.log(message);
        });
    };

    $scope.testar = function () {
        Pubnub.mobile_gw_provision({
            device_id: $scope.regId,
            channel: 'push',
            op: 'add',
            gw_type: 'apns',
            error: function (msg) { console.log(msg); },
            callback: successCallback
        });
    }

    function successCallback() {
        var message = PUBNUB.PNmessage();

        message.pubnub = Pubnub;
        message.callback = function (msg) { console.log(msg); };
        message.error = function (msg) { console.log(msg); };
        message.channel = "push";
        message.apns = {
            alert: $scope.msg
        };

        message.publish();
    }
}]);