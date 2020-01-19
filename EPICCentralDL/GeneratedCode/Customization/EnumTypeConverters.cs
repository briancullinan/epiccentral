using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace EPICCentralDL.Customization
{
	public abstract class EnumConverter<T> : TypeConverter
	{
		private readonly IList<Type> _validTypes = new[] { typeof(byte), typeof(short), typeof(int), typeof(long) };

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == null)
				throw new ArgumentNullException("sourceType");

			return _validTypes.Contains(sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == null)
				throw new ArgumentNullException("destinationType");

			return _validTypes.Contains(destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null)
				throw new ArgumentNullException("value");

		    var valType = value.GetType().IsEnum ? Enum.GetUnderlyingType(value.GetType()) : value.GetType();
            if (_validTypes.Contains(valType))
				return Enum.ToObject(typeof(T), value);

			throw new NotSupportedException("Cannot convert from type " + value.GetType());
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
				throw new ArgumentNullException("destinationType");

			if (value == null)
				throw new ArgumentNullException("value");

			if (!(value is T))
				throw new NotSupportedException("Value to convert is not of type " + typeof(T));

			return Convert.ChangeType(value, destinationType, culture ?? CultureInfo.InvariantCulture);
		}

		public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
		{
			return default(T);
		}
	}

	public class OrganizationTypeConverter : EnumConverter<OrganizationType>
	{
	}

	public class LicenseModeTypeConverter : EnumConverter<LicenseMode>
	{
	}

	public class AccountRestrictionTypeConverter : EnumConverter<AccountRestrictionType>
	{
	}

	public class DeviceStateTypeConverter : EnumConverter<DeviceState>
	{
	}

	public class EventTypeConverter : EnumConverter<EventType>
	{
	}

	public class MessageTypeConverter : EnumConverter<MessageType>
	{
	}

	public class ScanTypeConverter : EnumConverter<ScanType>
	{
	}

	public class GenderConverter : EnumConverter<Gender>
	{
	}

    public class TreatmentTypeConverter : EnumConverter<TreatmentType>
    {
    }

	// ReSharper disable InconsistentNaming
	//public class NBAnalysisGroupConverter : EnumConverter<NBAnalysisGroup>
	// ReSharper restore InconsistentNaming
	//{
	//}

	public class OrganComponentConverter : EnumConverter<OrganComponent>
	{
	}
}
