(function () {
    "use strict";

    document.addEventListener('deviceready', onDeviceReady.bind(this), false);

    function onDeviceReady() {
        document.addEventListener('pause', onPause.bind(this), false);
        document.addEventListener('resume', onResume.bind(this), false);

        navigator.geolocation.getCurrentPosition(onSuccessLoca, onErrorLoca, { maximumAge: 0, timeout: 10000, enableHighAccuracy: true });
    };

    function onPause() {
    };

    function onResume() {
    };

    function onSuccessLoca(position) {
        var loc = position.coords.latitude + ';' +
                   position.coords.longitude + ';' +
                   position.coords.accuracy;

        localStorage.setItem("localizacao", loc);
    }

    function onErrorLoca(error) {
    }
})();