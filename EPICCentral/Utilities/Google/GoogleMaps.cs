using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml.Linq;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Utilities.Google
{
	public static class GoogleMaps
	{
		public const string GOOGLEMAPS_URL = "http://maps.googleapis.com/maps/api/";
		public const string GOOGLEMAPS_GEOCODE_URL = GOOGLEMAPS_URL + "geocode/";

		public static decimal[] GetGeocode(LocationEntity location, bool update = true)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(location.AddressLine1);
			if (!string.IsNullOrWhiteSpace(location.AddressLine2))
				sb.Append(", ").Append(location.AddressLine2);
			sb.Append(", ").Append(location.City).Append(" ").Append(location.State);

			decimal[] geocode = GetGeocode(sb.ToString());

			if (update)
			{
				location.Latitude = geocode[0];
				location.Longitude = geocode[1];
			}

			return geocode;
		}

		public static decimal[] GetGeocode(string address)
		{
			string url = string.Format("{0}xml?sensor=false&address={1}", GOOGLEMAPS_GEOCODE_URL, HttpUtility.HtmlEncode(address));
			XElement response = GetXml(url);
			if (response == null)
				return null;

			string status = (string)(from element in response.Descendants("status") select element).First();
			if (status != "OK")
				return null;

			XElement geometry = (from element in response.Descendants("geometry") select element).First();
			string sLat = (string)(from element in geometry.Descendants("lat") select element).First();
			string sLng = (string)(from element in geometry.Descendants("lng") select element).First();

			decimal lat;
			decimal lng;
			if (!decimal.TryParse(sLat, out lat) || !decimal.TryParse(sLng, out lng))
				return null;

			return new [] { lat, lng };
		}

		private static XElement GetXml(string url)
		{
			string response = Get(url);
			return response == null ? null : XElement.Parse(response);
		}

		private static string Get(string url)
		{
			HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
			if (request == null)
				return null;

			request.Method = "GET";
			request.Timeout = 5000;		// 5 seconds

			WebResponse response = request.GetResponse();
			Stream responseStream = response.GetResponseStream();
			if (responseStream == null)
				return null;

			using (StreamReader reader = new StreamReader(responseStream))
			{
				return reader.ReadToEnd();
			}
		}

        public static LatLng GetAverage(IEnumerable<LatLng> locations)
        {
            var vertices = locations.Select(l => l.Vertex);
            return new LatLng(new Vertex(vertices.Average(v => v.X), vertices.Average(v => v.Y), vertices.Average(v => v.Z)));
        }
	}

    public class LatLng
    {
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public LatLng(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public LatLng(LocationEntity location)
        {
            if(location.Latitude.HasValue && location.Longitude.HasValue)
            {
                Latitude = location.Latitude.Value;
                Longitude = location.Longitude.Value;
            }
            else
                throw new ArgumentException("Latitude or Longitude not set.", "location");
        }

        public LatLng(Vertex point)
        {
            var lon = Math.Atan2(point.Y, point.X);
            var hyp = Math.Sqrt(point.X*point.X + point.Y*point.Y);
            var lat = Math.Atan2(point.Z, hyp);
            Latitude = Convert.ToDecimal(lat*180/Math.PI);
            Longitude = Convert.ToDecimal(lon*180/Math.PI);
        }

        public Vertex Vertex
        {
            get
            {
                var lat = Convert.ToDouble(Latitude) * Math.PI / 180;
                var lon = Convert.ToDouble(Longitude) * Math.PI / 180;
                var x = Math.Cos(lat)*Math.Cos(lon);
                var y = Math.Cos(lat)*Math.Sin(lon);
                var z = Math.Sin(lat);
                return new Vertex(x, y, z);
            }
        }
    }

    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vertex(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class Marker
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Icon { get; set; }
        public string Content { get; set; }
        public int ZIndex { get; set; }
        public string Title { get; set; }
        public int MinZoom { get; set; }
        public int MaxZoom { get; set; }
        public IEnumerable<LatLng> Locations { get; set; } 
    }
}