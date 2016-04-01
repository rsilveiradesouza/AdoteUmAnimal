(function () {
    "use strict";

    var push;

    document.addEventListener('deviceready', onDeviceReady.bind(this), false);

    function onDeviceReady() {
        document.addEventListener('pause', onPause.bind(this), false);
        document.addEventListener('resume', onResume.bind(this), false);

        push = PushNotification.init({
            ios: {
                'badge': 'true',
                'sound': 'true',
                'alert': 'true'
            }
        });

        push.on('registration', tokenHandler);

        push.on('notification', onNotificationAPN);

        push.on('error', errorHandler);

        navigator.geolocation.getCurrentPosition(onSuccessLoca, onErrorLoca, { maximumAge: 0, timeout: 10000, enableHighAccuracy: true });
    };

    function tokenHandler(data) {
        var result = data.registrationId;

        window.localStorage.setItem('device_id', result);
        console.log("reg id", result);
    }

    function errorHandler(error) {
        console.log('Error: ' + error);
    }

    function onNotificationAPN(e) {
        console.log('onNotificationAPN called!');
        console.log(e);

        if (e.badge) {
            push.setApplicationIconBadgeNumber(successHandler, e.badge);
        }
        if (e.sound) {
            var sound = new Media(e.sound);
            sound.play();
        }
        if (e.alert) {
            navigator.notification.alert(e.alert);
        }
    }

    function onPause() {
    };

    function onResume() {
    };

    function onSuccessLoca(position) {
        var loc = position.coords.latitude + ';' +
                   position.coords.longitude + ';' +
                   position.coords.accuracy;

        console.log("Localização geo", loc);
        localStorage.setItem("localizacao", loc);
    }

    function onErrorLoca(error) {
        console.log("Erro geo", error);
    }
})();