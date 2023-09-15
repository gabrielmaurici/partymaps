const BRAZIL_COORDINATES = {
    lat: -8.504242358627168,
    lng: -56.55117202550775,
}

let map;

async function initMap() {

    var position = await GetCurrentPosition();

    const { Map } = await google.maps.importLibrary("maps");

    map = new Map(document.getElementById("map"), {
        zoom: position.current ? 14 : 4,
        center: position.position,
        mapId: "DEMO_MAP_ID",
    });

    const beachMarker = new google.maps.Marker({
        position: { lat: -25.42101772120352, lng: -49.259524923948334 },
        map,
        icon: {
            url: "https://www.eventim.com.br/campaign/fileadmin/fm_br/campaigns/2023/rhcp/rhcp-mainban-v4.jpg",
            scaledSize: new google.maps.Size(50, 50),
        },
      });
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
                    position: BRAZIL_COORDINATES
                };

                resolve(currentPosition)
            }

            navigator.geolocation.getCurrentPosition(success, error, options);
        } else {
            const currentPosition = {
                current: false,
                position: BRAZIL_COORDINATES
            };

            resolve(currentPosition)
        }
    })
}

initMap();