const apiKey = 'AIzaSyDLa6NLI1CdkhwiZeERKyVsgQRc1ORZXgE';

function initMap(cities) {

    // info about the map
    const map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 49.8175, lng: 15.4730 },
        zoom: 6,
        mapTypeControl: false, // Hide map type control buttons
        mapTypeIds: [google.maps.MapTypeId.ROADMAP, google.maps.MapTypeId.SATELLITE],
        streetViewControl: false, // Hide Street View control
    });


    // creation of control window
    const customControlDiv = document.createElement('div');
    customControlDiv.id = 'customControl';
    map.controls[google.maps.ControlPosition.TOP_RIGHT].push(customControlDiv);

    // Add content to the custom control
    customControlDiv.innerHTML = `
                <h3 id="map_title">Stisknutím přepnete</h3>
                <div id="map_control">
                    <img src="http://maps.google.com/mapfiles/ms/icons/red-dot.png" alt="Your Image" class="map_pin">
                    <p>Nefiltrované</p>
                    <img src="http://maps.google.com/mapfiles/ms/icons/blue-dot.png" alt="Your Image" class="map_pin">
                    <p>Filtrované</p>
                </div>
            ` 
    

    // Iterate through the array of cities and add markers
    cities.forEach(city => {
        getCoordinates(city, map);
    });
    
}

function getCoordinates(cityName, map) {
    const apiUrl = `https://maps.googleapis.com/maps/api/geocode/json?address=${encodeURIComponent(cityName)}&key=${apiKey}`;

    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            if (data.results.length > 0) {
                const location = data.results[0].geometry.location;
                console.log(`Coordinates for ${cityName}: Latitude ${location.lat}, Longitude ${location.lng}`);

                // Set the default marker color
                const defaultMarkerColor = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png';

                // Create a marker and set its position and default icon
                const marker = new google.maps.Marker({
                    position: location,
                    map: map,
                    title: cityName, // Initial title is the city name
                    icon: defaultMarkerColor,
                }); 


                // Optionally, you can add additional information to the marker
                const infowindow = new google.maps.InfoWindow({
                    content: `<strong>${cityName}</strong>`, // Display only the city name in the info window
                });

                // Add a mouseover event listener to show the info window
                marker.addListener('mouseover', function () {
                    infowindow.open(map, marker);
                });

                // Add a mouseout event listener to close the info window
                marker.addListener('mouseout', function () {
                    infowindow.close();
                });

                // Track the marker state
                let isMarkerClicked = false;
                let chosenCitiesArr = new Array(); 
                // Add a click event listener to toggle the marker color and update the title

                marker.addListener('click', function () {
                    if (!isMarkerClicked) {
                        const clickedMarkerColor = 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png';
                        marker.setIcon(clickedMarkerColor);

                        // Update the title to the city name when clicked
                        marker.setTitle(cityName);

                        // Optionally, you can open an info window when the marker is clicked
                        infowindow.open(map, marker);
                        chosenCitiesArr.push(cityName);
                    }
                    else {
                        marker.setIcon(defaultMarkerColor);
                        // Optionally, you can close the info window when the marker is clicked again
                        infowindow.close();
                        chosenCitiesArr.push(cityName);

                        //this need to be handled
                        chosenCitiesArr.pop()
                    }

                    // Toggle the marker state
                    isMarkerClicked = !isMarkerClicked;
                });

                // Center the map on the markers
                map.setCenter(location);
            } else {
                console.error(`Location not found for ${cityName}`);
            }
        })
        .catch(error => console.error('Error:', error));
}

