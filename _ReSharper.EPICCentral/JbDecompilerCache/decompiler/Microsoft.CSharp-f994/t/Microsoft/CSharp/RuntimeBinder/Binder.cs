// Type: Microsoft.CSharp.RuntimeBinder.Binder
// Assembly: Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\Microsoft.CSharp.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Microsoft.CSharp.RuntimeBinder
{
  /// <summary>
  /// Contains factory methods to create dynamic call site binders for CSharp.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public static class Binder
  {
    /// <summary>
    /// Initializes a new CSharp binary operation binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp binary operation binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="operation">The binary operation kind.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder BinaryOperation(CSharpBinderFlags flags, ExpressionType operation, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != CSharpBinderFlags.None;
      bool flag = (flags & CSharpBinderFlags.BinaryOperationLogical) != CSharpBinderFlags.None;
      CSharpBinaryOperationFlags binaryOperationFlags = CSharpBinaryOperationFlags.None;
      if (flag)
        binaryOperationFlags |= CSharpBinaryOperationFlags.LogicalOperation;
      return (CallSiteBinder) new CSharpBinaryOperationBinder(operation, isChecked, binaryOperationFlags, context, argumentInfo);
    }

    /// <summary>
    /// Initializes a new CSharp convert binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp convert binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="type">The type to convert to.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param>
    public static CallSiteBinder Convert(CSharpBinderFlags flags, Type type, Type context)
    {
      CSharpConversionKind conversionKind = (flags & CSharpBinderFlags.ConvertExplicit) != CSharpBinderFlags.None ? CSharpConversionKind.ExplicitConversion : ((flags & CSharpBinderFlags.ConvertArrayIndex) != CSharpBinderFlags.None ? CSharpConversionKind.ArrayCreationConversion : CSharpConversionKind.ImplicitConversion);
      bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != CSharpBinderFlags.None;
      return (CallSiteBinder) new CSharpConvertBinder(type, conversionKind, isChecked, context);
    }

    /// <summary>
    /// Initializes a new CSharp get index binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp get index binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder GetIndex(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      return (CallSiteBinder) new CSharpGetIndexBinder(context, argumentInfo);
    }

    /// <summary>
    /// Initializes a new CSharp get member binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp get member binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="name">The name of the member to get.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder GetMember(CSharpBinderFlags flags, string name, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      bool resultIndexed = (flags & CSharpBinderFlags.ResultIndexed) != CSharpBinderFlags.None;
      return (CallSiteBinder) new CSharpGetMemberBinder(name, resultIndexed, context, argumentInfo);
    }

    /// <summary>
    /// Initializes a new CSharp invoke binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp invoke binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder Invoke(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      bool flag = (flags & CSharpBinderFlags.ResultDiscarded) != CSharpBinderFlags.None;
      CSharpCallFlags flags1 = CSharpCallFlags.None;
      if (flag)
        flags1 |= CSharpCallFlags.ResultDiscarded;
      return (CallSiteBinder) new CSharpInvokeBinder(flags1, context, argumentInfo);
    }

    /// <summary>
    /// Initializes a new CSharp invoke member binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp invoke member binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="name">The name of the member to invoke.</param><param name="typeArguments">The list of type arguments specified for this invoke.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder InvokeMember(CSharpBinderFlags flags, string name, IEnumerable<Type> typeArguments, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      bool flag1 = (flags & CSharpBinderFlags.InvokeSimpleName) != CSharpBinderFlags.None;
      bool flag2 = (flags & CSharpBinderFlags.InvokeSpecialName) != CSharpBinderFlags.None;
      bool flag3 = (flags & CSharpBinderFlags.ResultDiscarded) != CSharpBinderFlags.None;
      CSharpCallFlags flags1 = CSharpCallFlags.None;
      if (flag1)
        flags1 |= CSharpCallFlags.SimpleNameCall;
      if (flag2)
        flags1 |= CSharpCallFlags.EventHookup;
      if (flag3)
        flags1 |= CSharpCallFlags.ResultDiscarded;
      return (CallSiteBinder) new CSharpInvokeMemberBinder(flags1, name, context, typeArguments, argumentInfo);
    }

    /// <summary>
    /// Initializes a new CSharp invoke constructor binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp invoke constructor binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder InvokeConstructor(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      return (CallSiteBinder) new CSharpInvokeConstructorBinder(CSharpCallFlags.None, context, argumentInfo);
    }

    /// <summary>
    /// Initializes a new CSharp is event binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp is event binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="name">The name of the event to look for.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param>
    public static CallSiteBinder IsEvent(CSharpBinderFlags flags, string name, Type context)
    {
      return (CallSiteBinder) new CSharpIsEventBinder(name, context);
    }

    /// <summary>
    /// Initializes a new CSharp set index binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp set index binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder SetIndex(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      return (CallSiteBinder) new CSharpSetIndexBinder((flags & CSharpBinderFlags.ValueFromCompoundAssignment) != CSharpBinderFlags.None, (flags & CSharpBinderFlags.CheckedContext) != CSharpBinderFlags.None, context, argumentInfo);
    }

    /// <summary>
    /// Initializes a new CSharp set member binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp set member binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="name">The name of the member to set.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder SetMember(CSharpBinderFlags flags, string name, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      bool isCompoundAssignment = (flags & CSharpBinderFlags.ValueFromCompoundAssignment) != CSharpBinderFlags.None;
      bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != CSharpBinderFlags.None;
      return (CallSiteBinder) new CSharpSetMemberBinder(name, isCompoundAssignment, isChecked, context, argumentInfo);
    }

    /// <summary>
    /// Initializes a new CSharp unary operation binder.
    /// </summary>
    /// 
    /// <returns>
    /// Returns a new CSharp unary operation binder.
    /// </returns>
    /// <param name="flags">The flags with which to initialize the binder.</param><param name="operation">The unary operation kind.</param><param name="context">The <see cref="T:System.Type"/> that indicates where this operation is used.</param><param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo"/> instances for the arguments to this operation.</param>
    public static CallSiteBinder UnaryOperation(CSharpBinderFlags flags, ExpressionType operation, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
    {
      bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != CSharpBinderFlags.None;
      return (CallSiteBinder) new CSharpUnaryOperationBinder(operation, isChecked, context, argumentInfo);
    }
  }
}
