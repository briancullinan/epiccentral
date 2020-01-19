using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web.Hosting;
using System.Web.Mvc;
using SharedRes;

namespace EPICCentral.Utilities.Information
{
    /// <summary>
    /// Translates cultures and countries using the resource files.
    /// </summary>
    public static class Cultures
    {
        public static IEnumerable<SelectListItem> GetCountries(this CultureInfo currentCulture)
        {
            return new[]
                       {
                           new SelectListItem {Text = General.NotSelected, Value = ""}
                       }
                .Concat(new[]
                            {
                                new RegionInfo(currentCulture.LCID != 4096 ? currentCulture.LCID : 409)
                            }.ToSelectList())
                .Concat(
                    CultureInfo.GetCultures(CultureTypes.SpecificCultures & ~CultureTypes.NeutralCultures)
                        .Where(x => x.LCID != 4096)
                        .Select(culture => new RegionInfo(culture.LCID))
                        .Distinct()
                        .ToSelectList());
        }

        public static IEnumerable<SelectListItem> GetLanguages(this CultureInfo currentCulture)
        {
            // print out the cultures to copy in to cultures resource
            //var cultures = String.Join("\n", CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures).Select(x => "_" + x.Name.Replace("-", "_")));

            return
                General.ResourceManager.EnumSatelliteLanguages().Select(
                    x => x == CultureInfo.InvariantCulture
                             ? new SelectListItem { Text = SharedRes.Cultures.ResourceManager.GetString("_en_US"), Value = "en-US", Selected = currentCulture.Name == "en-US" }
                             : new SelectListItem { Text = SharedRes.Cultures.ResourceManager.GetString("_" + x.Name.Replace("-", "_")), Value = x.Name, Selected = x == currentCulture });
        }

        // get cultures for a specific resource info

        private static IEnumerable<CultureInfo> EnumSatelliteLanguages(this ResourceManager manager)
        {
            ResourceSet set = manager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
            if (set != null)
                yield return CultureInfo.InvariantCulture;

            foreach (CultureInfo culture in EnumSatelliteLanguages())
            {
                set = manager.GetResourceSet(culture, true, false);
                if (set != null)
                    yield return culture;
            }
        }

        // determine what assemblies are available

        private static IEnumerable<CultureInfo> EnumSatelliteLanguages()
        {
            var resourceParent = HostingEnvironment.IsHosted
                                     ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin")
                                     : AppDomain.CurrentDomain.BaseDirectory;
            foreach (string directory in Directory.GetDirectories(resourceParent))
            {
                string name = Path.GetFileNameWithoutExtension(directory); // resource dir don't have an extension...

                // format is XX-YY, we discard directories that can't match.
                // could/should be replaced by a regex but we still need to catch cultures errors...
                if (name == null || name.Length > 5)
                    continue;

                CultureInfo culture;
                try
                {
                    culture = CultureInfo.GetCultureInfo(name);
                }
                catch
                {
                    // not a good directory...
                    continue;
                }

                string resName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) + ".resources.dll";
                if (File.Exists(Path.Combine(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"), name), resName)))
                    yield return culture;
            }
        }
    }
}