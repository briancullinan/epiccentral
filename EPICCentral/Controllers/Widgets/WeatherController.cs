using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers.Widgets
{
    public class WeatherController : WidgetController
    {
        [Serializable]
        public class Weather
        {
            public DateTime Day = DateTime.UtcNow.Date;
            public string Condition;
            public string WindDirection;
            public int WindSpeed;
            public string Icon;
        }

        [Serializable]
        public class Forecast : Weather
        {
            public int High;
            public int Low;
        }

        [Serializable]
        public class CurrentWeather : Weather
        {
            public int Humidity;
            public int Tempurature;
        }

        private static readonly Dictionary<int, IEnumerable<Weather>> Cache = new Dictionary<int,IEnumerable<Weather>>(); 
        private readonly string _worldWeatherKey = ConfigurationManager.AppSettings["WorldWeatherOnlineApi"];

        public override string Title
        {
            get { return ControllerRes.Widgets.Weather_Title; }
        }

        public LocationEntity Location { get; set; }
        //
        // GET: /Weather/
        public override ActionResult Load()
        {
            var location = new LinqMetaData().Location.WithPermissions().FirstOrDefault();
            if (location != null)
            {
                Location = location;
                return View(this);
            }
            return new EmptyResult();
        }

        public ActionResult Data(int location)
        {
            // get locations this user has access to
            var locations = new LinqMetaData().Location.WithPermissions().ToList();
            Location = locations.ElementAt(Math.Abs(location%locations.Count()));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return View(this);
        }

        private XmlReader CreateReader(string document)
        {
            return XmlReader.Create(new StringReader(document),
                                    new XmlReaderSettings
                                        {
                                            ConformanceLevel = ConformanceLevel.Fragment,
                                            ValidationType = ValidationType.None,
                                            ValidationFlags = XmlSchemaValidationFlags.None,
                                            IgnoreWhitespace = true
                                        });
        }

        public IEnumerable<Weather> GetWorldWeatherOnline(LocationEntity location)
        {
            var client = new WebClient();

            // download the weather for the location
            // http://free.worldweatheronline.com/feed/weather.ashx?key=e6365c3bdb173409122708&q=19.434,-99.139&num_of_days=5&format=xml
            var weather = "";
            try
            {
                weather =
                    client.DownloadString(
                        String.Format(
                            "http://free.worldweatheronline.com/feed/weather.ashx?key={0}&q={1},{2}&num_of_days=5&format=xml",
                            _worldWeatherKey, location.Latitude, location.Longitude));
            }
            catch
            {
                ModelState.AddModelError("weather", ControllerRes.Widgets.Weather_LocationError);
            }

            using (XmlReader reader = CreateReader(weather))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "current_condition")
                    {
                        // try to read the entire element
                        CurrentWeather current = null;
                        try
                        {
                            using (XmlReader eventReader = reader.ReadSubtree())
                            {
                                eventReader.Read();
                                var evtEl = XNode.ReadFrom(eventReader) as XElement;
                                current = new CurrentWeather
                                              {
                                                  Condition = evtEl.Element("weatherDesc").Value,
                                                  Day = DateTime.UtcNow.Date,
                                                  Humidity = int.Parse(evtEl.Element("humidity").Value),
                                                  Tempurature = int.Parse(evtEl.Element("temp_F").Value),
                                                  WindDirection = evtEl.Element("winddir16Point").Value,
                                                  WindSpeed = int.Parse(evtEl.Element("windspeedMiles").Value),
                                                  Icon = evtEl.Element("weatherIconUrl").Value
                                              };
                            }
                        }
                        catch
                        {
                            // eat it
                        }
                        if (current != null)
                            yield return current;
                    }
                    else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "weather")
                    {
                        Forecast forecast = null;
                        try
                        {
                            using (XmlReader eventReader = reader.ReadSubtree())
                            {
                                eventReader.Read();
                                var evtEl = XNode.ReadFrom(eventReader) as XElement;
                                forecast = new Forecast
                                               {
                                                   Condition = evtEl.Element("weatherDesc").Value,
                                                   Day = DateTime.Parse(evtEl.Element("date").Value),
                                                   WindDirection = evtEl.Element("winddir16Point").Value,
                                                   WindSpeed = int.Parse(evtEl.Element("windspeedMiles").Value),
                                                   High = int.Parse(evtEl.Element("tempMaxF").Value),
                                                   Low = int.Parse(evtEl.Element("tempMinF").Value),
                                                   Icon = evtEl.Element("weatherIconUrl").Value
                                               };
                            }
                        }
                        catch
                        {
                            // eat it
                        }
                        if (forecast != null)
                            yield return forecast;
                    }
                }
            }
        }

        /*
        public IEnumerable<Weather> GetGoogleWeather(LocationEntity location)
        {
            var client = new WebClient();
            var weather = "";
            try
            {
                weather = client.DownloadString("http://www.google.com/ig/api?weather=" + Location.PostalCode);
            }
            catch
            {
                ModelState.AddModelError("weather", ControllerRes.Widgets.Weather_LocationError);
            }

            using (XmlReader reader = CreateReader(weather))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "current_conditions")
                    {

                        // try to read the entire element
                        CurrentWeather current = null;
                        try
                        {
                            using (XmlReader eventReader = reader.ReadSubtree())
                            {
                                eventReader.Read();
                                var evtEl = XNode.ReadFrom(eventReader) as XElement;

                                var icon = (string) evtEl.Element("icon").Attribute("data");
                                var temp_f = (string) evtEl.Element("temp_f").Attribute("data");
                                var temp_c = (string) evtEl.Element("temp_c").Attribute("data");
                                var humidity = (string) evtEl.Element("humidity").Attribute("data");
                                var wind_condition = (string) evtEl.Element("wind_condition").Attribute("data");
                                current = new CurrentWeather
                                              {
                                                  Condition = evtEl.Element("condition").Attribute("data").Value,
                                                  Day = DateTime.UtcNow.Date,
                                                  High = 
                                              };
                            }
                        }
                        catch
                        {
                            // eat it
                        }
                        if (current != null)
                            yield return current;
                    }
                    else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "forecast_conditions")
                    {

                        // try to read the entire element
                        try
                        {
                            using (XmlReader eventReader = reader.ReadSubtree())
                            {
                                eventReader.Read();
                                var evtEl = XNode.ReadFrom(eventReader) as XElement;
                                // write the weather to the widget

                                var condition = (string) evtEl.Element("condition").Attribute("data");
                                var day = (string) evtEl.Element("day_of_week").Attribute("data");
                                var icon = (string) evtEl.Element("icon").Attribute("data");
                                var high = (string) evtEl.Element("high").Attribute("data");
                                var low = (string) evtEl.Element("low").Attribute("data");
                            }
                        }
                        catch
                        {
                            // eat it
                        }

                    }
                }
            }
        }
        */

        public override void Render(ViewContext viewContext, TextWriter writer)
        {
            var htmlHelper = new HtmlHelper<dynamic>(viewContext, this);

            // get weather for each day
            var wrapper =
                @"
<script type='text/javascript'>
    var weatherLocation = 0;
    function changeLocation(loc)
    {
        weatherLocation = loc;
        $('#WeatherController > table > tbody > tr > td').load('" +
                Url.Action("Data", "Weather") +
                @"?location=' + weatherLocation + ' > div');
    }
</script>
<div id='weather-title'>
    <button id='prev-location' type='button' onclick='changeLocation(weatherLocation-1);'><span class='ui-icon ui-icon-triangle-1-w'></span></button>
    <div id='weather-heading-title'>" +
                Location.Name + " (" + Location.City + ", " + Location.PostalCode + ")" +
                @"</div>
    <button id='next-location' type='button' onclick='changeLocation(weatherLocation+1);'><span class='ui-icon ui-icon-triangle-1-e'></span></button>
</div>
<div class='forecast'>" +
                htmlHelper.ValidationSummary(false);

            var current = "";
            var forecast = "";

            var currentWeather = !Cache.ContainsKey(Location.LocationId) ? null : Cache[Location.LocationId].FirstOrDefault(x => x is CurrentWeather) as CurrentWeather;
            if (currentWeather == null || currentWeather.Day != DateTime.UtcNow.Date)
            {
                Cache[Location.LocationId] = GetWorldWeatherOnline(Location).OrderBy(x => x.Day);
                currentWeather = Cache[Location.LocationId].FirstOrDefault(x => x is CurrentWeather) as CurrentWeather;
            }
            /*
            var weatherSetting = new SystemSettingEntity("LocationWeather-" + Location.LocationId);
            if(!weatherSetting.IsNew)
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(List<Weather>), new [] {typeof(CurrentWeather), typeof(Forecast)});
                    var stream = new StringReader(weatherSetting.Value);
                    all = (List<Weather>)serializer.Deserialize(stream);
                    if (all.First(x => x is CurrentWeather).Day != DateTime.UtcNow.Date)
                        all = null;
                }
                catch
                {
                    // eat it
                }
            }
            if(all == null)
            {
                all = GetWorldWeatherOnline(Location).OrderBy(x => x.Day);

                // save the weather
                try
                {
                    var serializer = new XmlSerializer(typeof(List<Weather>), new [] {typeof(CurrentWeather), typeof(Forecast)});
                    var stream = new MemoryStream();
                    serializer.Serialize(stream, all.ToList());
                    weatherSetting.Name = "LocationWeather-" + Location.LocationId;
                    weatherSetting.Value = Encoding.UTF8.GetString(stream.ToArray());
                    weatherSetting.Save();
                }
                catch
                {
                    // eat it
                }
            }
            */


            current +=
                String.Format(
                    @"
<div class='current'>
    <div class='icon'>
        <img width='40' height='40' alt='{0}' src='{1}'>
        <br />
    </div>
    <div class='tempurature'>{2}°F ({3}°C)</div>
    <div style='float:' class='conditions'>
        Current:&nbsp;{0}<br />{4}<br />{5}
    </div>
</div>",
                    currentWeather.Condition,
                    currentWeather.Icon,
                    currentWeather.Tempurature,
                    (currentWeather.Tempurature - 32)*5/9,
                    String.Format("{0} at {1} {2}", currentWeather.WindDirection, currentWeather.WindSpeed, "mph"),
                    currentWeather.Humidity);

            forecast = Cache[Location.LocationId].OfType<Forecast>().Aggregate(forecast,
                                                        (current1, forecastWeather) =>
                                                        current1 +
                                                        String.Format(
                                                            @"
<div title='{0}' class='fore'>
    {1}<br />
    <div class='icon'>
        <img width='40' height='40' alt='{0}' src='{2}'>
    </div>
    <span>{3}°&nbsp;|&nbsp;{4}°</span>
</div>",
                                                            forecastWeather.Condition, forecastWeather.Day.DayOfWeek,
                                                            forecastWeather.Icon, forecastWeather.High,
                                                            forecastWeather.Low));

            // write the weather to the widget
            writer.Write(wrapper + current + forecast + "</div>");
        }
    }
}
