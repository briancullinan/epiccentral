using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Web.Mvc;
using EPICCentralDL.Customization;
using System.Web.Mvc.Html;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SharedRes;

/// <summary>
/// Creates SelectLists for various entity types.
/// </summary>
public static class SelectListExtensions
{
    public static IEnumerable<SelectListItem> ToSelectList(this Enum type)
    {
        var enumType = type.GetType();
        return new[]
                   {
                       new SelectListItem {Text = General.NotSelected, Value = ""}
                   }.Concat(
                       Enum.GetNames(enumType).Select(
                           x =>
                               {
                                   var member = Enum.Parse(type.GetType(), x);
                                   return new SelectListItem
                                              {Text = GetDisplayText(member as Enum), Value = member.ToString()};
                               }));
    }

    public static string GetDisplayText(this Enum type)
    {
        var enumType = type.GetType();
        var member = type.ToString();
        var display =
            enumType.GetMember(member).Single().GetCustomAttributes(typeof(DisplayAttribute),
                                                               false).OfType
                <DisplayAttribute>().SingleOrDefault();
        return display != null ? display.GetName() : member;
    }

    public static IEnumerable<SelectListItem> ToSelectList(this bool value)
    {
        return new[]
                   {
                       new SelectListItem
                           {
                               Text = General.NotSelected,
                               Value = ""
                           },
                       new SelectListItem
                           {
                               Text = "True",
                               Value = "True"
                           },
                       new SelectListItem
                           {
                               Text = "False",
                               Value = "False"
                           },
                   };
    }

    public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<EntityBase> items)
    {
        var type = items.GetType().GetGenericArguments()[0];
        var typeName = type.Namespace.Replace("EntityClasses", "HelperClasses") + "." +
                       type.Name.Replace("Entity", "Fields");
        var fieldsType = Assembly.GetAssembly(type).GetType(typeName);
        if (fieldsType != null)
        {
            var fields =
                fieldsType.GetProperties().Select(
                    x =>
                    ((EntityField) x.GetValue(null, BindingFlags.Static, null, null, CultureInfo.InvariantCulture)));
            var primary = fields.Where(x => x.IsPrimaryKey);

            var property = -1;
            if (fields.Any(x => x.Name == "Name"))
                property = fields.First(x => x.Name == "Name").FieldIndex;
            else if (fields.Any(x => x.Name == "Description"))
                property = fields.First(x => x.Name == "Description").FieldIndex;

            if (property > -1)
            {
                if (primary.Any())
                {
                    return new[]
                               {
                                   new SelectListItem {Text = General.NotSelected, Value = ""}
                               }.Concat(
                                   items.Select(
                                       x =>
                                       new SelectListItem
                                           {
                                               Text =
                                                   String.Format("[{0}] {1}",
                                                                 x.GetCurrentFieldValue(primary.First().FieldIndex),
                                                                 x.GetCurrentFieldValue(property)),
                                               Value = x.GetCurrentFieldValue(primary.First().FieldIndex).ToString()
                                           }));
                }
                return new[]
                           {
                               new SelectListItem {Text = General.NotSelected, Value = ""}
                           }.Concat(
                               items.Select(
                                   x =>
                                   new SelectListItem
                                       {
                                           Text = String.Format("{0}", x.GetCurrentFieldValue(property)),
                                           Value = x.GetCurrentFieldValue(property).ToString()
                                       }));
            }
        }
        return new List<SelectListItem>();
    }

    public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<OrganizationEntity> organizations)
    {
        return new[]
                   {
                       new SelectListItem {Text = General.NotSelected, Value = ""}
                   }.Concat(

                       organizations.Select(
                           x =>
                           new SelectListItem
                               {
                                   Text = Formats.Organization.FormatWith(x),
                                   Value = x.OrganizationId.ToString(CultureInfo.InvariantCulture)
                               }));
    }

    public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<DeviceEntity> devices)
    {
        return new[]
                   {
                       new SelectListItem {Text = General.NotSelected, Value = ""}
                   }.Concat(

                       devices.Select(
                           x =>
                           new SelectListItem
                               {
                                   Text = Formats.Device.FormatWith(x),
                                   Value = x.DeviceId.ToString(CultureInfo.InvariantCulture)
                               }));
    }

    public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<ScanRateEntity> rates)
    {
        return
            new[]
                {
                    new SelectListItem {Text = General.NotSelected, Value = ""}
                }.Concat(
                    rates.Select(
                        x =>
                        new SelectListItem
                            {
                                Text = Formats.ScanRate.FormatWith(x),
                                Value = x.ScanRateId.ToString(CultureInfo.InvariantCulture)
                            }));
    }

    public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<RegionInfo> regions)
    {
        return regions
            .Select(region => new SelectListItem
                                  {
                                      Text =
                                          Countries.ResourceManager.GetString(
                                              region.TwoLetterISORegionName.StartsWith("0")
                                                  ? "_" + region.TwoLetterISORegionName.Substring(1)
                                                  : region.TwoLetterISORegionName),
                                      Value = region.TwoLetterISORegionName
                                  })
            .OrderBy(x => x.Text);
    }

    public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<CreditCardEntity> cards)
    {
        return new[]
                   {
                       new SelectListItem {Text = General.NotSelected, Value = ""}
                   }.Concat(cards.Select(card => new SelectListItem
                                                      {
                                                          Text = SharedRes.Formats.CreditCard.FormatWith(card),
                                                          Value = card.CreditCardId.ToString(CultureInfo.InvariantCulture)
                                                      }));
    }

    public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<EPICCentral.Utilities.Information.TimeZones.TimeZone> zones)
    {
        return zones
            .OrderBy(x => x.Type)
            .OrderBy(x => TimeZoneInfo.FindSystemTimeZoneById(x.Zone).BaseUtcOffset.Hours)
            .Select(x => new SelectListItem
                             {
                                 Text =
                                     String.Format("({1:D2}00) {0}", x.Type,
                                                   TimeZoneInfo.FindSystemTimeZoneById(x.Zone).BaseUtcOffset.Hours),
                                 Value = x.Type
                             })
            .DistinctBy(x => x.Value);
    }
}