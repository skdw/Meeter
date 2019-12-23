function initMap() {
    var map_center = { lat: 52.2322, lng: 21.0083 };
    generateMap();

    function getLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(setPosition);
        } else { 
            console.log("Geolocation is not supported by this browser.");
            generateMap();
        }
    }

    function setPosition(position) {
        map_center = { lat: position.coords.latitude, lng: position.coords.longitude };
        generateMap();
    }

    function generateMap() {
        var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 13,
        center: map_center,
        disableDefaultUI: true,
        gestureHandling: 'none',
        styles: style_silver // or style_retro
    });
    }
    
    getLocation();
}