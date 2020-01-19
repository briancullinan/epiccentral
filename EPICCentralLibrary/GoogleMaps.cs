using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using EPICCentralDL.Linq;

namespace EPICCentralLibrary
{
	public class LatLng
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public LatLng()
		{
		}

		public LatLng(double lat, double lng)
		{
			Latitude = lat;
			Longitude = lng;
		}
	}

	public class GoogleMaps
	{
		private string API_KEY = string.Empty;
		public GoogleMaps(string api_key)
		{
			API_KEY = api_key;
		}

		public void SetApiKey(string key)
		{
			if (String.IsNullOrEmpty(key))
			{
				throw new ArgumentException("API Key is invalid");
			}
			API_KEY = key;
		}

		/// <summary>  
		/// Perform a geocode lookup of an address  
		/// </summary>  
		/// <param name="addr">The address in CSV form line1, line2, postcode</param>  
		/// <returns>LatLng object</returns>  
		public LatLng GetLatLng(string addr)
		{
			var url = "http://maps.google.com/maps/geo?output=csv&key=" +
					   API_KEY + "&q=" + HttpContext.Current.Server.UrlEncode(addr);
			var request = WebRequest.Create(url);

			var response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var ms = new MemoryStream();
				var responseStream = response.GetResponseStream();
				var buffer = new Byte[2048];
				int count = responseStream.Read(buffer, 0, buffer.Length);
				while (count > 0)
				{
					ms.Write(buffer, 0, count);
					count = responseStream.Read(buffer, 0, buffer.Length);
				}
				responseStream.Close();
				ms.Close();
				var responseBytes = ms.ToArray();
				var encoding = new System.Text.ASCIIEncoding();
				var coords = encoding.GetString(responseBytes);
				var parts = coords.Split(',');
				return new LatLng(
							  Convert.ToDouble(parts[2]),
							  Convert.ToDouble(parts[3]));
			}
			return null;
		}

		public static String GenerateGoogleMapsJSHeader(string GoogleMapsApiKey, string NameOfDIVForMap, string ClientIdValue)
		{
			string header_js = "";
			try
			{
				header_js += @"
					<script src='http://maps.googleapis.com/maps/api/js?sensor=false&amp;key={0}' type='text/javascript'></script>
					<script type='text/javascript'>
						var map;
						var markersArray = [];

						$(document).ready(function () {
							initialize();					
						});

						function reloadMap() { 
							if(document.getElementById('{2}').value == '1') 
							{
								document.getElementById('{2}').value = '0';
								initialize();
							}
						}

						function initialize() {
							if(!map)
							{
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
									}],
									mapTypeControl: false,
									streetViewControl: false,
									overviewMapControl: false
								};
								map = new google.maps.Map(document.getElementById('{1}'), mapOptions);
							}
							else
								clearOverlays();
							addMarkers()
						}

						function clearOverlays() {
						  if (markersArray) {
							for (i in markersArray) {
							  markersArray[i].setMap(null);
							}
							markersArray.length = 0;
						  }
						}

					
					</script>
					".Replace("{0}", GoogleMapsApiKey)
					 .Replace("{1}", NameOfDIVForMap)
					 .Replace("{2}", ClientIdValue);

				return header_js;
			}
			catch
			{
				return header_js;
			}
		}

		public static string CreateActivityMapJS()
		{
			string map_js = "";
			try
			{
				map_js += @"
					<script type='text/javascript'>
					function addMarkers() {
					";
				LinqMetaData m = new LinqMetaData();
				var locations = (from ac in m.ActiveOrganization
				                 select ac.LocationId).Distinct();
				foreach (var location in locations)
				{
					int location1 = location;
					var activeOrganizations = from ac in m.ActiveOrganization
											  orderby ac.ActivityTime descending
											  where ac.LocationId == location1
											  select ac;
					var activeOrganization = activeOrganizations.FirstOrDefault();
					if (activeOrganization != null)
					{
						string icon = "";
						switch (activeOrganization.ActivityTypeId)
						{
						case 0:
							icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CCCC00|666600";
							break;
						case 1:
							icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|00CC00|006600";
							break;
						case 2:
							icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|6666CC|333366";
							break;
						case 3:
							icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC0000|660000";
							break;
						case 4:
							icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC9900|663300";
							break;
						}
						if (activeOrganization.Location.Latitude != null && activeOrganization.Location.Longitude != null)
							map_js += @"
						marker = new google.maps.Marker({
							position: new google.maps.LatLng({lat},{lng}),
							map: map,
							icon: new google.maps.MarkerImage('{i}',
								new google.maps.Size(21, 34),
								new google.maps.Point(0, 0),
								new google.maps.Point(0, 34))
						});
						markersArray.push(marker);
						".Replace("{lat}", activeOrganization.Location.Latitude.ToString())
								 .Replace("{lng}", activeOrganization.Location.Longitude.ToString())
								 .Replace("{i}", icon);
					}
				}

				map_js += @"  
					}
					</script>";

				return map_js;
			}
			catch (Exception)
			{
				return map_js;
			}
		}

	}
}
