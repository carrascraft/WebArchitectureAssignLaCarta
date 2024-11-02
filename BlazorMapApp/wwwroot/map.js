function initMap(coordinates) {
    var map = L.map('map').setView([coordinates[0].lat, coordinates[0].lng], 13);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    coordinates.forEach(coord => {
        L.marker([coord.lat, coord.lng]).addTo(map);
    });
}