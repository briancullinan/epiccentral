// Type: System.ComponentModel.DataAnnotations.DisplayAttribute
// Assembly: System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.ComponentModel.DataAnnotations.dll

using System;
using System.ComponentModel.DataAnnotations.Resources;
using System.Globalization;
using System.Runtime;

namespace System.ComponentModel.DataAnnotations
{
  /// <summary>
  /// Provides a general-purpose attribute that lets you specify localizable strings for types and members of entity partial classes.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
  [__DynamicallyInvokable]
  public sealed class DisplayAttribute : Attribute
  {
    private LocalizableString _shortName = new LocalizableString("ShortName");
    private LocalizableString _name = new LocalizableString("Name");
    private LocalizableString _description = new LocalizableString("Description");
    private LocalizableString _prompt = new LocalizableString("Prompt");
    private LocalizableString _groupName = new LocalizableString("GroupName");
    private Type _resourceType;
    private bool? _autoGenerateField;
    private bool? _autoGenerateFilter;
    private int? _order;

    /// <summary>
    /// Gets or sets a value that is used for the grid column label.
    /// </summary>
    /// 
    /// <returns>
    /// A value that is for the grid column label.
    /// </returns>
    [__DynamicallyInvokable]
    public string ShortName
    {
      [__DynamicallyInvokable] get
      {
        return this._shortName.Value;
      }
      [__DynamicallyInvokable] set
      {
        if (!(this._shortName.Value != value))
          return;
        this._shortName.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value that is used for display in the UI.
    /// </summary>
    /// 
    /// <returns>
    /// A value that is used for display in the UI.
    /// </returns>
    [__DynamicallyInvokable]
    public string Name
    {
      [__DynamicallyInvokable] get
      {
        return this._name.Value;
      }
      [__DynamicallyInvokable] set
      {
        if (!(this._name.Value != value))
          return;
        this._name.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value that is used to display a description in the UI.
    /// </summary>
    /// 
    /// <returns>
    /// The value that is used to display a description in the UI.
    /// </returns>
    [__DynamicallyInvokable]
    public string Description
    {
      [__DynamicallyInvokable] get
      {
        return this._description.Value;
      }
      [__DynamicallyInvokable] set
      {
        if (!(this._description.Value != value))
          return;
        this._description.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value that will be used to set the watermark for prompts in the UI.
    /// </summary>
    /// 
    /// <returns>
    /// A value that will be used to display a watermark in the UI.
    /// </returns>
    [__DynamicallyInvokable]
    public string Prompt
    {
      [__DynamicallyInvokable] get
      {
        return this._prompt.Value;
      }
      [__DynamicallyInvokable] set
      {
        if (!(this._prompt.Value != value))
          return;
        this._prompt.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value that is used to group fields in the UI.
    /// </summary>
    /// 
    /// <returns>
    /// A value that is used to group fields in the UI.
    /// </returns>
    [__DynamicallyInvokable]
    public string GroupName
    {
      [__DynamicallyInvokable] get
      {
        return this._groupName.Value;
      }
      [__DynamicallyInvokable] set
      {
        if (!(this._groupName.Value != value))
          return;
        this._groupName.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the type that contains the resources for the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ShortName"/>, <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Name"/>, <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Prompt"/>, and <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Description"/> properties.
    /// </summary>
    /// 
    /// <returns>
    /// The type of the resource that contains the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ShortName"/>, <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Name"/>, <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Prompt"/>, and <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Description"/> properties.
    /// </returns>
    [__DynamicallyInvokable]
    public Type ResourceType
    {
      [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this._resourceType;
      }
      [__DynamicallyInvokable] set
      {
        if (!(this._resourceType != value))
          return;
        this._resourceType = value;
        this._shortName.ResourceType = value;
        this._name.ResourceType = value;
        this._description.ResourceType = value;
        this._prompt.ResourceType = value;
        this._groupName.ResourceType = value;
      }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether UI should be generated automatically in order to display this field.
    /// </summary>
    /// 
    /// <returns>
    /// true if UI should be generated automatically to display this field; otherwise, false.
    /// </returns>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to get the property value before it was set.</exception>
    [__DynamicallyInvokable]
    public bool AutoGenerateField
    {
      [__DynamicallyInvokable] get
      {
        if (this._autoGenerateField.HasValue)
          return this._autoGenerateField.Value;
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, DataAnnotationsResources.DisplayAttribute_PropertyNotSet, new object[2]
        {
          (object) "AutoGenerateField",
          (object) "GetAutoGenerateField"
        }));
      }
      [__DynamicallyInvokable] set
      {
        this._autoGenerateField = new bool?(value);
      }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether filtering UI is automatically displayed for this field.
    /// </summary>
    /// 
    /// <returns>
    /// true if UI should be generated automatically to display filtering for this field; otherwise, false.
    /// </returns>
    /// <exception cref="T:System.InvalidOperationException">An attempt was made to get the property value before it was set.</exception>
    [__DynamicallyInvokable]
    public bool AutoGenerateFilter
    {
      [__DynamicallyInvokable] get
      {
        if (this._autoGenerateFilter.HasValue)
          return this._autoGenerateFilter.Value;
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, DataAnnotationsResources.DisplayAttribute_PropertyNotSet, new object[2]
        {
          (object) "AutoGenerateFilter",
          (object) "GetAutoGenerateFilter"
        }));
      }
      [__DynamicallyInvokable] set
      {
        this._autoGenerateFilter = new bool?(value);
      }
    }

    /// <summary>
    /// Gets or sets the order weight of the column.
    /// </summary>
    /// 
    /// <returns>
    /// The order weight of the column.
    /// </returns>
    [__DynamicallyInvokable]
    public int Order
    {
      [__DynamicallyInvokable] get
      {
        if (this._order.HasValue)
          return this._order.Value;
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, DataAnnotationsResources.DisplayAttribute_PropertyNotSet, new object[2]
        {
          (object) "Order",
          (object) "GetOrder"
        }));
      }
      [__DynamicallyInvokable] set
      {
        this._order = new int?(value);
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.ComponentModel.DataAnnotations.DisplayAttribute"/> class.
    /// </summary>
    [__DynamicallyInvokable]
    public DisplayAttribute()
    {
    }

    /// <summary>
    /// Returns the value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ShortName"/> property.
    /// </summary>
    /// 
    /// <returns>
    /// The localized string for the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ShortName"/> property if the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> property has been specified and if the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ShortName"/> property represents a resource key; otherwise, the non-localized value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ShortName"/> value property.
    /// </returns>
    [__DynamicallyInvokable]
    public string GetShortName()
    {
      return this._shortName.GetLocalizableValue() ?? this.GetName();
    }

    /// <summary>
    /// Returns a value that is used for field display in the UI.
    /// </summary>
    /// 
    /// <returns>
    /// The localized string for the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Name"/> property, if the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> property has been specified and the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Name"/> property represents a resource key; otherwise, the non-localized value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Name"/> property.
    /// </returns>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> property and the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Name"/> property are initialized, but a public static property that has a name that matches the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Name"/> value could not be found for the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> property.</exception>
    [__DynamicallyInvokable]
    public string GetName()
    {
      return this._name.GetLocalizableValue();
    }

    /// <summary>
    /// Returns the value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Description"/> property.
    /// </summary>
    /// 
    /// <returns>
    /// The localized description, if the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> has been specified and the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Description"/> property represents a resource key; otherwise, the non-localized value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Description"/> property.
    /// </returns>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> property and the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Description"/> property are initialized, but a public static property that has a name that matches the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Description"/> value could not be found for the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> property.</exception>
    [__DynamicallyInvokable]
    public string GetDescription()
    {
      return this._description.GetLocalizableValue();
    }

    /// <summary>
    /// Returns the value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Prompt"/> property.
    /// </summary>
    /// 
    /// <returns>
    /// Gets the localized string for the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Prompt"/> property if the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> property has been specified and if the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Prompt"/> property represents a resource key; otherwise, the non-localized value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Prompt"/> property.
    /// </returns>
    [__DynamicallyInvokable]
    public string GetPrompt()
    {
      return this._prompt.GetLocalizableValue();
    }

    /// <summary>
    /// Returns the value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.GroupName"/> property.
    /// </summary>
    /// 
    /// <returns>
    /// A value that will be used for grouping fields in the UI, if <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.GroupName"/> has been initialized; otherwise, null. If the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType"/> property has been specified and the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.GroupName"/> property represents a resource key, a localized string is returned; otherwise, a non-localized string is returned.
    /// </returns>
    [__DynamicallyInvokable]
    public string GetGroupName()
    {
      return this._groupName.GetLocalizableValue();
    }

    /// <summary>
    /// Returns the value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.AutoGenerateField"/> property.
    /// </summary>
    /// 
    /// <returns>
    /// The value of <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.AutoGenerateField"/> if the property has been initialized; otherwise, null.
    /// </returns>
    [__DynamicallyInvokable]
    public bool? GetAutoGenerateField()
    {
      return this._autoGenerateField;
    }

    /// <summary>
    /// Returns a value that indicates whether UI should be generated automatically in order to display filtering for this field.
    /// </summary>
    /// 
    /// <returns>
    /// The value of <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.AutoGenerateFilter"/> if the property has been initialized; otherwise, null.
    /// </returns>
    [__DynamicallyInvokable]
    public bool? GetAutoGenerateFilter()
    {
      return this._autoGenerateFilter;
    }

    /// <summary>
    /// Returns the value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Order"/> property.
    /// </summary>
    /// 
    /// <returns>
    /// The value of the <see cref="P:System.ComponentModel.DataAnnotations.DisplayAttribute.Order"/> property, if it has been set; otherwise, null.
    /// </returns>
    [__DynamicallyInvokable]
    public int? GetOrder()
    {
      return this._order;
    }
  }
}
