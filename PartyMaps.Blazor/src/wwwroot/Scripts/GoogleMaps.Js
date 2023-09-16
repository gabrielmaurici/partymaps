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

    const { AdvancedMarkerView } = await google.maps.importLibrary("marker");

    const advancedMarkerView = new AdvancedMarkerView({
        map,
        content: buildContent(),
        position: { lat: -25.42101772120352, lng: -49.259524923948334 },
        title: "Red Hot Chili Peppers",
    });
    
    CreateSearchBox();


    var port = window.location.port;
    var domain = window.location.hostname + (port ? ":" + port : "");

    const contentString =
        `<div>
            <h4>Red Hot Chili Peppers Curitiba</h4>
        </div>
        <div class="event-content">
            <div>
                <img class="event-image" src="https://www.eventim.com.br/campaign/fileadmin/fm_br/campaigns/2023/rhcp/rhcp-mainban-v4.jpg" />
            </div>
            <div class="event-details">
                <div>
                    <h6>Descricao</h6>
                    <p>O show do Red Hot Chili Peppers promete ser uma explosão de energia e música envolvente. Prepare-se para ser cativado por hits icônicos da banda, uma performance cheia de paixão e uma atmosfera eletrizante que certamente aquecerá sua noite de novembro. Não perca a oportunidade de vivenciar a lendária fusão de rock e funk do Red Hot Chili Peppers ao vivo neste evento imperdível.</p>
                </div>
                <div>
                    <h6>Preço</h6> <p>R$960,00
                </div>
                <div>
                    <h6>Data</h6> <p>13/11/2023
                </div>
                <div>
                    <h6>Horário</h6> <p>16:00
                </div>
                <div>
                    <a class="button" href=http://${domain}/chat/1>Entrar no chat do evento</a>
                </div>
            </div>
        </div>


        <style>
            p { 
                font-size: 13.5px; 
            }

            .event-content {
                display: flex;
                justify-content: space-between

                height: 100%;
                align-items: center;
            }

            .event-image {
                height: 400px;
                margin-right: 15px;
            }

            .event-details {
                display: flex;
                flex-direction: column;
                justify-content: space-between;
                height: 400px;
            }

            .button {
                display: inline-block;
                padding: 10px 20px;
                background-color: #231455;
                color: #FFFFFF;
                text-decoration: none;
                border: 1px solid #231455;
                border-radius: 5px;
                font-weight: bold;
            }

            .button:hover {
                color: #231455;
                background-color: #FFFFFF;
            }
        </style>`
    ;

    const infowindow = new google.maps.InfoWindow({
        content: contentString,
        ariaLabel: "Red Hot Chili Peppers",
    });

    advancedMarkerView.addListener("click", () => {
        infowindow.open({
            anchor: advancedMarkerView,
            map,
        });
    });
}

function CreateSearchBox() {
    const input = document.getElementById("pac-input");
    const searchBox = new google.maps.places.SearchBox(input);
  
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
    // Bias the SearchBox results towards current map's viewport.
    map.addListener("bounds_changed", () => {
        searchBox.setBounds(map.getBounds());
    });
  
  
    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener("places_changed", () => {
        const places = searchBox.getPlaces();
  
        if (places.length == 0) {
            return;
        }
  
        // For each place, get the icon, name and location.
        const bounds = new google.maps.LatLngBounds();
  
        places.forEach((place) => {
            if (!place.geometry || !place.geometry.location) {
                console.log("Returned place contains no geometry");
                return;
            }

            if (place.geometry.viewport) {
                // Only geocodes have viewport.
                bounds.union(place.geometry.viewport);
            } else {
                bounds.extend(place.geometry.location);
            }
        });

        map.fitBounds(bounds);
    });
}

function buildContent() {
    const content = document.createElement("div");
  
    content.classList.add("property");
    content.innerHTML = `
        <div class="map-marker">
            <img style="height: 50px; width: 50px; border-radius: 50%;" src="https://www.eventim.com.br/campaign/fileadmin/fm_br/campaigns/2023/rhcp/rhcp-mainban-v4.jpg" >
        </div>
        <style>
            .map-marker {
                background-color: #ffff;
                border: 3px solid #ffff;
                border-radius: 50%;
            }

            .map-marker::before {
                content: ' ';
                height: 0;
                width: 0;
                border: 12.5px solid transparent;
                border-top-color: #ffff;
                position: absolute;
                top: 53.4px;
                left: 16.3px;
            }
        </style>

      `;
    return content;
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

window.initMap = initMap