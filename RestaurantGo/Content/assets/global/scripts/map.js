


var nombre;
var direccion;
var ubicacion ;
var id_ubicacion;
var map;
var marker;
var markers;
var posicion;
var saludo = "hola";
var vista;

var autocomplete;
var input;
var infowindow;
var geocoder;
var marker;
var plece;
var latlang;



    function initMap() {
    
            vista = window.location.pathname;
            vista = vista.split('/');
            vista = vista[2];
            latlang = '{ lat: 18.473807, lng: -69.913407 }';


                     //en esta sesion esta la localizacion por defecto del mapa
            map = new google.maps.Map(document.getElementById('map'),
                {
                    center: { lat: 18.473807, lng: -69.913407 },
              zoom: 17
                });


                            // en esta sesion se configura la funcionalidad de autocompletado del buscardor
          input = document.getElementById('pac-input');
          autocomplete = new google.maps.places.Autocomplete(
              input, { placeIdOnly: true }
              );

          autocomplete.bindTo('bounds', map);
          map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);


          infowindow = new google.maps.InfoWindow();
          geocoder = new google.maps.Geocoder;
          marker = new google.maps.Marker({
              map: map
          });


          if (vista != 'Create' && vista != 'Edit') {
              geocodePlaceId(geocoder, map, infowindow);
              return;
          }
          if ( vista == 'Edit') {
              geocodePlaceId(geocoder, map, infowindow);

          }

          marker.addListener('click', function() {
              infowindow.open(map, marker);
           
          });


          autocomplete.addListener('place_changed', function () {

              infowindow.close();
              place = autocomplete.getPlace();
              if (!place.place_id) {
                  return;
              }


              //var pathname = window.location.pathname;
              //var vista = pathname.split('/');
              //var placeId;

              //if (vista[2] != 'Create' && vista[2] != 'Edit') {
              //    placeId = document.getElementById('id_ubicacion').innerHTML;
              //    geocodePlaceId(geocoder, map, infowindow);

                  
              //} else {
              //    placeId = place.place_id
              //}

              geocoder.geocode({ 'placeId': place.place_id }, function (results, status) {

                  if (status !== 'OK') {
                      window.alert('Geocoder failed due to: ' + status);
                      return;
                  } 
                  map.setZoom(17);
                  map.setCenter(results[0].geometry.location);

                  // Set the position of the marker using the place ID and location.
                  marker.setPlace({
                      placeId: place.place_id,
                      location: results[0].geometry.location
                  });
                  marker.setVisible(true);

                  try{
                      document.getElementById('place-name').textContent = place.name;
                      document.getElementById('place-id').textContent = place.place_id;
                      document.getElementById('place-address').textContent =
                      results[0].formatted_address;
                  }catch(err)
                  {

                  }
                      

                  infowindow.setContent(document.getElementById('infowindow-content'));
                  infowindow.open(map, marker);

                  cargarDatos(place, results);

              });
          });
      }


// This function is called when the user clicks the UI button requesting
// a reverse geocode.
function geocodePlaceId(geocoder, map, infowindow) {
    var placeId;
    if (vista == 'Edit') {
        nombre = document.getElementById('nombre').value;
        ubicacion = document.getElementById('ubicacion').value;
        id_ubicacion = document.getElementById('id_ubicacion').value;
        placeId = document.getElementById('id_ubicacion').value;

    } else {
        nombre = document.getElementById('nombre').innerHTML;
        ubicacion = document.getElementById('ubicacion').innerHTML;
        id_ubicacion = document.getElementById('id_ubicacion').innerHTML;
        placeId = document.getElementById('id_ubicacion').innerHTML;

    }



     geocoder.geocode({ 'placeId': placeId }, function (results, status) {
        if (status === 'OK') {
            if (results[0]) {
                map.setZoom(17);
                map.setCenter(results[0].geometry.location);
                 marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });

                marker.setVisible(true);
                document.getElementById('place-name').textContent = nombre;
                document.getElementById('place-id').textContent = id_ubicacion;
                document.getElementById('place-address').textContent =  results[0].formatted_address;
                infowindow.setContent(document.getElementById('infowindow-content'));
                infowindow.open(map, marker);


            } else {
                window.alert('No results found');
            }
        } else {
            window.alert('Geocoder failed due to: ' + status);
        }
  
    });
}


    function cargarDatos(p_place,p_result) {
       


        var preinf = p_place.name
        ubicacion = p_result[0].geometry.location.toString();
        ubicacion = ubicacion.split('(');
        ubicacion = ubicacion[1];
        ubicacion = ubicacion.split(')');
        ubicacion = ubicacion[0];
        id_ubicacion = p_place.place_id;
        nombre = p_place.name.split(',');
        nombre = nombre[0];
        direccion = preinf.substring(nombre.length + 2);

          //En esta sesion se cargan los campos del formulario
        document.getElementById('nombre').value = nombre;
        document.getElementById('direccion').value = direccion;
        document.getElementById('ubicacion').value = ubicacion;
        document.getElementById('id_ubicacion').value = id_ubicacion;

    }