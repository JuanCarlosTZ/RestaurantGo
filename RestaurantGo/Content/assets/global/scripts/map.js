


var nombre = '';
var direccion = '';
var ubicacion = '';
var id_ubicacion = '';

function cargarDatos(preinf) {

    nombre = preinf.split(',')[0];
    direccion = preinf.substring(nombre.length + 2);

    document.getElementById('nombre').value = nombre;
    document.getElementById('direccion').value = direccion;
    document.getElementById('ubicacion').value = ubicacion;
    document.getElementById('id_ubicacion').value = id_ubicacion;
    
        }

function initMap() {

          var map = new google.maps.Map(document.getElementById('map'), {
              center: {lat: 18.473807, lng:  -69.913407},
              zoom: 18
          });
     
          var input = document.getElementById('pac-input');

          var autocomplete = new google.maps.places.Autocomplete(
              input, {placeIdOnly: true});
          autocomplete.bindTo('bounds', map);

          map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

          var infowindow = new google.maps.InfoWindow();
          var geocoder = new google.maps.Geocoder;
          var marker = new google.maps.Marker({
              map: map
          });


          var pathname = window.location.pathname;
          var vista = pathname.split('/');



          if (vista[2] != 'Create' && vista[2] != 'Edit') {
              geocodePlaceId(geocoder, map, infowindow);

              return;
          }



          marker.addListener('click', function() {
              infowindow.open(map, marker);
          });

          autocomplete.addListener('place_changed', function() {
              infowindow.close();
            
              var place = autocomplete.getPlace();
         
              if (!place.place_id) {
                  return;
              }


              var pathname = window.location.pathname;
              var vista = pathname.split('/');
              var placeId;

              if (vista[2] != 'Create' && vista[2] != 'Edit') {
                  placeId = document.getElementById('id_ubicacion').innerHTML;
                  geocodePlaceId(geocoder, map, infowindow);

                  
              } else {
                  placeId = place.place_id
              }

              geocoder.geocode({ 'placeId': placeId }, function (results, status) {
          

                  if (status !== 'OK') {
                      window.alert('Geocoder failed due to: ' + status);
                      return;
                  }
                  map.setZoom(18);
                  map.setCenter(results[0].geometry.location);
                  // Set the position of the marker using the place ID and location.

                  marker.setPlace({
                      placeId: place.placeId,
                      location: results[0].geometry.location
                  });
                  marker.setVisible(true);
                  document.getElementById('place-name').textContent = place.name;
                  document.getElementById('place-id').textContent = place.place_id;
                  document.getElementById('place-address').textContent =
                      results[0].formatted_address;
                  infowindow.setContent(document.getElementById('infowindow-content'));
                  infowindow.open(map, marker);
                

                  var preinf = place.name
                  ubicacion = results[0].geometry.location;
                  id_ubicacion = place.place_id;
                  cargarDatos(preinf);

              });
          });
      }


// This function is called when the user clicks the UI button requesting
// a reverse geocode.
function geocodePlaceId(geocoder, map, infowindow) {
    // var placeId = ChIJXaeqAtZu1moR6Q7DmBg4Jt; document.getElementById('id_ubicacion').value;

    nombre = document.getElementById('nombre').innerHTML;
    var ubicacion = document.getElementById('ubicacion').innerHTML;
    id_ubicacion = document.getElementById('id_ubicacion').innerHTML;
    var placeId = document.getElementById('id_ubicacion').innerHTML;

    var input = document.getElementById('pac-input');

    var autocomplete = new google.maps.places.Autocomplete(
        input, {placeIdOnly: true});
    autocomplete.bindTo('bounds', map);

    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    var infowindow = new google.maps.InfoWindow();
    var geocoder = new google.maps.Geocoder;
    var marker = new google.maps.Marker({
        map: map
    });


    geocoder.geocode({ 'placeId': placeId }, function (results, status) {
        if (status === 'OK') {
            if (results[0]) {
                map.setZoom(18);
                map.setCenter(results[0].geometry.location);
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });



                marker.setVisible(true);
                document.getElementById('place-name').textContent = nombre;
                document.getElementById('place-id').textContent = id_ubicacion;
                document.getElementById('place-address').textContent =
                    results[0].formatted_address;
                infowindow.setContent(document.getElementById('infowindow-content'));
                infowindow.open(map, marker);


                //marker.setVisible(true);
                //document.getElementById('place-name').textContent = 'place.name';
                //document.getElementById('place-id').textContent = 'place.place_id';

                //document.getElementById('place-name').textContent = 'nombre';
                //document.getElementById('place-id').textContent = 'id';

                //infowindow.setContent(results[0].formatted_address);
                //infowindow.open(map, marker);


            } else {
                window.alert('No results found');
            }
        } else {
            window.alert('Geocoder failed due to: ' + status);
        }


  
    });
}



      // This function is called when the user clicks the UI button requesting
// a reverse geocode.



//function geocodePlaceId(geocoder, map, infowindow) {

//    ubicacion = document.getElementById('ubicacion').innerHTML;
//    var placeId = document.getElementById('id_ubicacion').innerHTML;
//        var ubicacionParte = ubicacion.split(',');
//        var latitud = ubicacionParte[0].split('(')[1];
//        var longitud = ubicacionParte[1].split(')')[0];
//        alert(latitud);
//        alert(longitud);
//        alert(ubicacion);

    
//        var map = new google.maps.Map(document.getElementById('map'), {
//            center: {lat: latitud, lng:  longitud},
//            zoom: 18
//        });


 
//        marker = new google.maps.Marker({
//            map: map
//        });




//        if (!placeId) {
//                return;
//        }

//        geocoder.geocode({ 'placeId': placeId }, function (results, status) {

//                if (status !== 'OK') {
//                    window.alert('Geocoder failed due to: ' + status);
//                    return;
//                }
//                map.setZoom(18);
//                map.setCenter(results[0].geometry.location);
//                // Set the position of the marker using the place ID and location.

       
                 
//                marker.setPlace({
//                    placeId: place.place_id,
//                    location: results[0].geometry.location
//                });
//                marker.setVisible(true);
//                document.getElementById('place-name').textContent = place.name;
//                document.getElementById('place-id').textContent = place.place_id;
//                document.getElementById('place-address').textContent =
//                    results[0].formatted_address;
//                infowindow.setContent(document.getElementById('infowindow-content'));
//                infowindow.open(map, marker);

//                alert(results[0].formatted_address);
//                var preinf = place.name
//                ubicacion = results[0].geometry.location;
//                id_ubicacion = place.place_id;

//            });
//      }

