let map;

async function initMap() {
    
    const position = { lat: -27.114221, lng: -48.910285 };
    
    const { Map } = await google.maps.importLibrary("maps");
    const { AdvancedMarkerView } = await google.maps.importLibrary("marker");
    
    map = new Map(document.getElementById("map"), {
        zoom: 18,
        center: position,
        mapId: "DEMO_MAP_ID",
    });
    
    const marker = new AdvancedMarkerView({
        map: map,
        position: position,
        title: "Casa Maumau",
    });    
}

initMap();