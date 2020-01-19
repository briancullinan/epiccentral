using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using SharedRes;

namespace EPICCentral.Utilities.Information
{
    /// <summary>
    /// Maps TZID zones to windows zones because Microsoft can't use standards they didn't invent.
    /// </summary>
    public static class TimeZones
    {
        private static readonly XDocument Doc = XDocument.Load(Global.VirtualPathProvider.GetFile("~/Content/windowsZones.xml").Open());
        public static readonly IEnumerable<TimeZone> Zones = Doc
            .Descendants("windowsZones").First()
            .Descendants("mapTimezones").First()
            .Descendants("mapZone")
            .SelectMany(x => x.Attribute("type").Value.Split(' '), 
                (element, s) => new TimeZone
                                    {
                                        Zone = element.Attribute("other").Value,
                                        Territory = element.Attribute("territory").Value,
                                        Type = s
                                    });

        public static IEnumerable<SelectListItem> GetTimeZones(this TimeZoneInfo currentZone)
        {
            return new[]
                       {
                           new SelectListItem {Text = General.NotSelected, Value = ""},
                       }
                .Concat(Zones.Where(x => x.Zone == currentZone.Id).ToSelectList())
                .Concat(Zones.ToSelectList());
        }

        public class TimeZone
        {
            public string Zone { get; set; }
            public string Territory { get; set; }
            public string Type { get; set; }
        }
    }
}