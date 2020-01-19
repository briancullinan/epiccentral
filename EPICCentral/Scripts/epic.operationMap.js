var map;
var infoWindow;
var mgr;
var settings;

function initializeGoogleMap(config) {
    settings = config;
    if (!map) {
        var mapOptions = {
            zoom: Math.round($('#map_canvas').width() / $('#map_canvas').height()),
            scrollwheel: false,
            center: new google.maps.LatLng(45.05, 7.6667),
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            styles: [{
                featureType: 'all',
                stylers: [
                        { hue: '#CCCCEE' }
                    ]
            }, {
                featureType: 'water',
                stylers: [
                        { hue: '#0022AA' }
                    ]
            }, {
                featureType: 'road',
                stylers: [
                        { hue: '#AABB66' }
                    ]
            }],
            mapTypeControl: false,
            streetViewControl: false,
            overviewMapControl: false
        };
        map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);
        $('#main').bind('resize', function () {
            google.maps.event.trigger(map, "resize");
        });
    }
    mgr = new MarkerManager(map);
    google.maps.event.addListener(mgr, 'loaded', function () {
        RefreshOperations();
    });
    //google.maps.event.addListenerOnce(map, 'idle', RefreshOperations);
    infoWindow = new google.maps.InfoWindow();
}

function RefreshOperations() {
    $.ajax({
        url: settings.url
    })
    .done(function (data) {
        mgr.clearMarkers();
        if (typeof (data.daily) != 'undefined') {
            var daily = '<tr><th colspan="3">' + settings.daily + '</th></tr>';
            for (var stat in data.daily) {
                daily += '<tr>';
                daily += '<td><img width="10" height="17" alt="" src="' + data.daily[stat].Icon + '"></td>';
                daily += '<td>' + data.daily[stat].Text + '</td>';
                daily += '<td>' + data.daily[stat].Count + '</td>';
                daily += '</tr>';
            }
            $('#operation-daily').html(daily);
        }
        if (typeof (data.system) != 'undefined') {
            var system = '<tr><th colspan="4">' + settings.overall + '</th></tr>';
            for (var sys in data.system) {
                system += '<tr>';
                system += '<td><img width="10" height="17" alt="" src="' + data.system[sys].Icon + '"></td>';
                system += '<td>' + data.system[sys].Text + '</td>';
                system += '<td><img width="16" height="16" alt="" src="' + data.system[sys].Arrow + '"></td>';
                system += '<td>' + data.system[sys].Count + '</td>';
                system += '</tr>';
            }
            $('#operation-system').html(system);
        }
        if (typeof (data.markers) != 'undefined') {
            for (var i in data.markers) {
                var newMarker = new google.maps.Marker({
                    position: new google.maps.LatLng(data.markers[i].Latitude, data.markers[i].Longitude),
                    content: data.markers[i].Content,
                    icon: new google.maps.MarkerImage(data.markers[i].Icon,
                        new google.maps.Size(21, 34),
                        new google.maps.Point(0, 0),
                        new google.maps.Point(11, 34)),
                    zIndex: data.markers[i].ZIndex,
                    title: data.markers[i].Title
                });
                mgr.addMarker(newMarker, data.markers[i].MinZoom, data.markers[i].MaxZoom);
                if (typeof (data.markers[i].Locations) != undefined) {
                    for (var j in data.markers[i].Locations) {
                        var locations = [
                            new google.maps.LatLng(
                                data.markers[i].Locations[j].Latitude,
                                data.markers[i].Locations[j].Longitude),
                            new google.maps.LatLng(
                                data.markers[i].Latitude, data.markers[i].Longitude)
                        ];
                        var locationLeg = new google.maps.Polyline({
                            path: locations,
                            strokeColor: '#996633',
                            strokeOpacity: 1.0,
                            strokeWeight: 2
                        });
                        locationLeg.setMap(map);
                    }
                }
                google.maps.event.addListener(newMarker, 'click', function () {
                    map.panTo(this.getPosition());
                    infoWindow.setContent(this.content);
                    infoWindow.setPosition(this.getPosition());
                    infoWindow.open(map);
                });
            }
        }
        $('body').layout('resizeAll', true);
    });
}
