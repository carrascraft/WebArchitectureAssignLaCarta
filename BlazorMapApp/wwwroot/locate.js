// wwwroot/js/locationHelper.js
window.getLocation = function () {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    resolve([position.coords.latitude, position.coords.longitude]);
                },
                (error) => {
                    reject("Unable to retrieve location: " + error.message);
                }
            );
        } else {
            reject("Geolocation is not supported by this browser.");
        }
    });
};
