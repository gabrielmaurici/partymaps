let map;

async function initMap() {
    
    var position = await GetCurrentPosition();

    const { Map } = await google.maps.importLibrary("maps");
    const { AdvancedMarkerView } = await google.maps.importLibrary("marker");
    
    map = new Map(document.getElementById("map"), {
        zoom: position.current ? 14 : 4,
        center: position.position,
        mapId: "DEMO_MAP_ID",
    });
    
    // const marker = new AdvancedMarkerView({
    //     map: map,
    //     position: position.pos,
    //     title: "Casa Maumau",
    // });    
}

async function GetCurrentPosition() {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            var options = {
                enableHighAccuracy: true,
                timeout: 5000,
                maximumAge: 0,
            };
            
            function success(pos) {
                const currentPosition = {
                    current: true,
                    position: {
                        lat: pos.coords.latitude,
                        lng: pos.coords.longitude,
                    }
                };
                
                resolve(currentPosition);
            }
                
            function error() {
                const currentPosition = {
                    current: false,
                    position: {
                        lat: -8.504242358627168,
                        lng: -56.55117202550775,
                    }
                };
    
                resolve(currentPosition)
            }
            
            navigator.geolocation.getCurrentPosition(success, error, options);
        }
    })
}

initMap();