using System;
using System.Linq;
using EPICCentralDL.EntityClasses;

public static class FormatExtensions
{
    /// <summary>
    /// Formats a string with the specified object using the index of all properties on the object.
    /// Format string already does this, this is just for convenience.
    /// </summary>
    /// <param name="format"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static string FormatWith(this string format, CommonEntityBase entity)
    {
        return String.Format(format, entity.Fields.Select(x => x.CurrentValue).ToArray());
    }

    public static string FormatWith(this string format, object obj)
    {
        var values = obj.GetType().GetProperties().Select(x => x.GetValue(obj, null)).ToArray();
        return String.Format(format, values);
    }
}
