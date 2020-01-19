// Type: Microsoft.VisualStudio.TestTools.UnitTesting.Assert
// Assembly: Microsoft.VisualStudio.QualityTools.UnitTestFramework, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: c:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\PublicAssemblies\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll

using Microsoft.VisualStudio.TestTools.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
  public static class Assert
  {
    internal static EventHandler<EventArgs> AssertionFailure;

    public static void IsTrue(bool condition)
    {
      Assert.IsTrue(condition, string.Empty, (object[]) null);
    }

    public static void IsTrue(bool condition, string message)
    {
      Assert.IsTrue(condition, message, (object[]) null);
    }

    public static void IsTrue(bool condition, string message, params object[] parameters)
    {
      if (condition)
        return;
      Assert.HandleFail("Assert.IsTrue", message, parameters);
    }

    public static void IsFalse(bool condition)
    {
      Assert.IsFalse(condition, string.Empty, (object[]) null);
    }

    public static void IsFalse(bool condition, string message)
    {
      Assert.IsFalse(condition, message, (object[]) null);
    }

    public static void IsFalse(bool condition, string message, params object[] parameters)
    {
      if (!condition)
        return;
      Assert.HandleFail("Assert.IsFalse", message, parameters);
    }

    public static void IsNull(object value)
    {
      Assert.IsNull(value, string.Empty, (object[]) null);
    }

    public static void IsNull(object value, string message)
    {
      Assert.IsNull(value, message, (object[]) null);
    }

    public static void IsNull(object value, string message, params object[] parameters)
    {
      if (value == null)
        return;
      Assert.HandleFail("Assert.IsNull", message, parameters);
    }

    public static void IsNotNull(object value)
    {
      Assert.IsNotNull(value, string.Empty, (object[]) null);
    }

    public static void IsNotNull(object value, string message)
    {
      Assert.IsNotNull(value, message, (object[]) null);
    }

    public static void IsNotNull(object value, string message, params object[] parameters)
    {
      if (value != null)
        return;
      Assert.HandleFail("Assert.IsNotNull", message, parameters);
    }

    public static void AreSame(object expected, object actual)
    {
      Assert.AreSame(expected, actual, string.Empty, (object[]) null);
    }

    public static void AreSame(object expected, object actual, string message)
    {
      Assert.AreSame(expected, actual, message, (object[]) null);
    }

    public static void AreSame(object expected, object actual, string message, params object[] parameters)
    {
      if (object.ReferenceEquals(expected, actual))
        return;
      string message1 = message;
      if (expected is ValueType && actual is ValueType)
        message1 = (string) FrameworkMessages.AreSameGivenValues(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message));
      Assert.HandleFail("Assert.AreSame", message1, parameters);
    }

    public static void AreNotSame(object notExpected, object actual)
    {
      Assert.AreNotSame(notExpected, actual, string.Empty, (object[]) null);
    }

    public static void AreNotSame(object notExpected, object actual, string message)
    {
      Assert.AreNotSame(notExpected, actual, message, (object[]) null);
    }

    public static void AreNotSame(object notExpected, object actual, string message, params object[] parameters)
    {
      if (!object.ReferenceEquals(notExpected, actual))
        return;
      Assert.HandleFail("Assert.AreNotSame", message, parameters);
    }

    public static void AreEqual<T>(T expected, T actual)
    {
      Assert.AreEqual<T>(expected, actual, string.Empty, (object[]) null);
    }

    public static void AreEqual<T>(T expected, T actual, string message)
    {
      Assert.AreEqual<T>(expected, actual, message, (object[]) null);
    }

    public static void AreEqual<T>(T expected, T actual, string message, params object[] parameters)
    {
      if (object.Equals((object) expected, (object) actual))
        return;
      Assert.HandleFail("Assert.AreEqual", (object) actual == null || (object) expected == null || actual.GetType().Equals(expected.GetType()) ? (string) FrameworkMessages.AreEqualFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) Assert.ReplaceNulls((object) expected), (object) Assert.ReplaceNulls((object) actual)) : (string) FrameworkMessages.AreEqualDifferentTypesFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) Assert.ReplaceNulls((object) expected), (object) expected.GetType().FullName, (object) Assert.ReplaceNulls((object) actual), (object) actual.GetType().FullName), parameters);
    }

    public static void AreNotEqual<T>(T notExpected, T actual)
    {
      Assert.AreNotEqual<T>(notExpected, actual, string.Empty, (object[]) null);
    }

    public static void AreNotEqual<T>(T notExpected, T actual, string message)
    {
      Assert.AreNotEqual<T>(notExpected, actual, message, (object[]) null);
    }

    public static void AreNotEqual<T>(T notExpected, T actual, string message, params object[] parameters)
    {
      if (!object.Equals((object) notExpected, (object) actual))
        return;
      Assert.HandleFail("Assert.AreNotEqual", (string) FrameworkMessages.AreNotEqualFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) Assert.ReplaceNulls((object) notExpected), (object) Assert.ReplaceNulls((object) actual)), parameters);
    }

    public static void AreEqual(object expected, object actual)
    {
      Assert.AreEqual(expected, actual, string.Empty, (object[]) null);
    }

    public static void AreEqual(object expected, object actual, string message)
    {
      Assert.AreEqual(expected, actual, message, (object[]) null);
    }

    public static void AreEqual(object expected, object actual, string message, params object[] parameters)
    {
      Assert.AreEqual<object>(expected, actual, message, parameters);
    }

    public static void AreNotEqual(object notExpected, object actual)
    {
      Assert.AreNotEqual(notExpected, actual, string.Empty, (object[]) null);
    }

    public static void AreNotEqual(object notExpected, object actual, string message)
    {
      Assert.AreNotEqual(notExpected, actual, message, (object[]) null);
    }

    public static void AreNotEqual(object notExpected, object actual, string message, params object[] parameters)
    {
      Assert.AreNotEqual<object>(notExpected, actual, message, parameters);
    }

    public static void AreEqual(float expected, float actual, float delta)
    {
      Assert.AreEqual(expected, actual, delta, string.Empty, (object[]) null);
    }

    public static void AreEqual(float expected, float actual, float delta, string message)
    {
      Assert.AreEqual(expected, actual, delta, message, (object[]) null);
    }

    public static void AreEqual(float expected, float actual, float delta, string message, params object[] parameters)
    {
      if ((double) Math.Abs(expected - actual) <= (double) delta)
        return;
      Assert.HandleFail("Assert.AreEqual", (string) FrameworkMessages.AreEqualDeltaFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) expected.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat), (object) actual.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat), (object) delta.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat)), parameters);
    }

    public static void AreNotEqual(float notExpected, float actual, float delta)
    {
      Assert.AreNotEqual(notExpected, actual, delta, string.Empty, (object[]) null);
    }

    public static void AreNotEqual(float notExpected, float actual, float delta, string message)
    {
      Assert.AreNotEqual(notExpected, actual, delta, message, (object[]) null);
    }

    public static void AreNotEqual(float notExpected, float actual, float delta, string message, params object[] parameters)
    {
      if ((double) Math.Abs(notExpected - actual) > (double) delta)
        return;
      Assert.HandleFail("Assert.AreNotEqual", (string) FrameworkMessages.AreNotEqualDeltaFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) notExpected.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat), (object) actual.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat), (object) delta.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat)), parameters);
    }

    public static void AreEqual(double expected, double actual, double delta)
    {
      Assert.AreEqual(expected, actual, delta, string.Empty, (object[]) null);
    }

    public static void AreEqual(double expected, double actual, double delta, string message)
    {
      Assert.AreEqual(expected, actual, delta, message, (object[]) null);
    }

    public static void AreEqual(double expected, double actual, double delta, string message, params object[] parameters)
    {
      if (Math.Abs(expected - actual) <= delta)
        return;
      Assert.HandleFail("Assert.AreEqual", (string) FrameworkMessages.AreEqualDeltaFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) expected.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat), (object) actual.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat), (object) delta.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat)), parameters);
    }

    public static void AreNotEqual(double notExpected, double actual, double delta)
    {
      Assert.AreNotEqual(notExpected, actual, delta, string.Empty, (object[]) null);
    }

    public static void AreNotEqual(double notExpected, double actual, double delta, string message)
    {
      Assert.AreNotEqual(notExpected, actual, delta, message, (object[]) null);
    }

    public static void AreNotEqual(double notExpected, double actual, double delta, string message, params object[] parameters)
    {
      if (Math.Abs(notExpected - actual) > delta)
        return;
      Assert.HandleFail("Assert.AreNotEqual", (string) FrameworkMessages.AreNotEqualDeltaFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) notExpected.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat), (object) actual.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat), (object) delta.ToString((IFormatProvider) CultureInfo.CurrentCulture.NumberFormat)), parameters);
    }

    public static void AreEqual(string expected, string actual, bool ignoreCase)
    {
      Assert.AreEqual(expected, actual, ignoreCase, string.Empty, (object[]) null);
    }

    public static void AreEqual(string expected, string actual, bool ignoreCase, string message)
    {
      Assert.AreEqual(expected, actual, ignoreCase, message, (object[]) null);
    }

    public static void AreEqual(string expected, string actual, bool ignoreCase, string message, params object[] parameters)
    {
      Assert.AreEqual(expected, actual, ignoreCase, CultureInfo.InvariantCulture, message, parameters);
    }

    public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture)
    {
      Assert.AreEqual(expected, actual, ignoreCase, culture, string.Empty, (object[]) null);
    }

    public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message)
    {
      Assert.AreEqual(expected, actual, ignoreCase, culture, message, (object[]) null);
    }

    public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
    {
      Assert.CheckParameterNotNull((object) culture, "Assert.AreEqual", "culture", string.Empty, new object[0]);
      if (string.Compare(expected, actual, ignoreCase, culture) == 0)
        return;
      Assert.HandleFail("Assert.AreEqual", ignoreCase || string.Compare(expected, actual, true, culture) != 0 ? (string) FrameworkMessages.AreEqualFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) Assert.ReplaceNulls((object) expected), (object) Assert.ReplaceNulls((object) actual)) : (string) FrameworkMessages.AreEqualCaseFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) Assert.ReplaceNulls((object) expected), (object) Assert.ReplaceNulls((object) actual)), parameters);
    }

    public static void AreNotEqual(string notExpected, string actual, bool ignoreCase)
    {
      Assert.AreNotEqual(notExpected, actual, ignoreCase, string.Empty, (object[]) null);
    }

    public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message)
    {
      Assert.AreNotEqual(notExpected, actual, ignoreCase, message, (object[]) null);
    }

    public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message, params object[] parameters)
    {
      Assert.AreNotEqual(notExpected, actual, ignoreCase, CultureInfo.InvariantCulture, message, parameters);
    }

    public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture)
    {
      Assert.AreNotEqual(notExpected, actual, ignoreCase, culture, string.Empty, (object[]) null);
    }

    public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message)
    {
      Assert.AreNotEqual(notExpected, actual, ignoreCase, culture, message, (object[]) null);
    }

    public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
    {
      Assert.CheckParameterNotNull((object) culture, "Assert.AreNotEqual", "culture", string.Empty, new object[0]);
      if (string.Compare(notExpected, actual, ignoreCase, culture) != 0)
        return;
      Assert.HandleFail("Assert.AreNotEqual", (string) FrameworkMessages.AreNotEqualFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) Assert.ReplaceNulls((object) notExpected), (object) Assert.ReplaceNulls((object) actual)), parameters);
    }

    public static void IsInstanceOfType(object value, Type expectedType)
    {
      Assert.IsInstanceOfType(value, expectedType, string.Empty, (object[]) null);
    }

    public static void IsInstanceOfType(object value, Type expectedType, string message)
    {
      Assert.IsInstanceOfType(value, expectedType, message, (object[]) null);
    }

    public static void IsInstanceOfType(object value, Type expectedType, string message, params object[] parameters)
    {
      if (expectedType == (Type) null)
        Assert.HandleFail("Assert.IsInstanceOfType", message, parameters);
      if (expectedType.IsInstanceOfType(value))
        return;
      Assert.HandleFail("Assert.IsInstanceOfType", (string) FrameworkMessages.IsInstanceOfFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) expectedType.ToString(), value == null ? (object) (string) FrameworkMessages.Common_NullInMessages : (object) value.GetType().ToString()), parameters);
    }

    public static void IsNotInstanceOfType(object value, Type wrongType)
    {
      Assert.IsNotInstanceOfType(value, wrongType, string.Empty, (object[]) null);
    }

    public static void IsNotInstanceOfType(object value, Type wrongType, string message)
    {
      Assert.IsNotInstanceOfType(value, wrongType, message, (object[]) null);
    }

    public static void IsNotInstanceOfType(object value, Type wrongType, string message, params object[] parameters)
    {
      if (wrongType == (Type) null)
        Assert.HandleFail("Assert.IsNotInstanceOfType", message, parameters);
      if (value == null || !wrongType.IsInstanceOfType(value))
        return;
      Assert.HandleFail("Assert.IsNotInstanceOfType", (string) FrameworkMessages.IsNotInstanceOfFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) wrongType.ToString(), (object) value.GetType().ToString()), parameters);
    }

    public static void Fail()
    {
      Assert.Fail(string.Empty, (object[]) null);
    }

    public static void Fail(string message)
    {
      Assert.Fail(message, (object[]) null);
    }

    public static void Fail(string message, params object[] parameters)
    {
      Assert.HandleFail("Assert.Fail", message, parameters);
    }

    public static void Inconclusive()
    {
      Assert.Inconclusive(string.Empty, (object[]) null);
    }

    public static void Inconclusive(string message)
    {
      Assert.Inconclusive(message, (object[]) null);
    }

    public static void Inconclusive(string message, params object[] parameters)
    {
      string str = string.Empty;
      if (!string.IsNullOrEmpty(message))
        str = parameters != null ? string.Format((IFormatProvider) CultureInfo.CurrentCulture, Assert.ReplaceNulls((object) message), parameters) : Assert.ReplaceNulls((object) message);
      throw new AssertInconclusiveException(FrameworkMessages.AssertionFailed((object) "Assert.Inconclusive", (object) str));
    }

    public new static bool Equals(object objA, object objB)
    {
      Assert.Fail((string) FrameworkMessages.DoNotUseAssertEquals);
      return false;
    }

    internal static void HandleFail(string assertionName, string message, params object[] parameters)
    {
      string str = string.Empty;
      if (!string.IsNullOrEmpty(message))
        str = parameters != null ? string.Format((IFormatProvider) CultureInfo.CurrentCulture, Assert.ReplaceNulls((object) message), parameters) : Assert.ReplaceNulls((object) message);
      if (Assert.AssertionFailure != null)
        Assert.AssertionFailure((object) null, EventArgs.Empty);
      throw new AssertFailedException(FrameworkMessages.AssertionFailed((object) assertionName, (object) str));
    }

    internal static void CheckParameterNotNull(object param, string assertionName, string parameterName, string message, params object[] parameters)
    {
      if (param != null)
        return;
      Assert.HandleFail(assertionName, (string) FrameworkMessages.NullParameterToAssert((object) parameterName, (object) message), parameters);
    }

    internal static string ReplaceNulls(object input)
    {
      if (input == null)
        return FrameworkMessages.Common_NullInMessages.ToString();
      string input1 = input.ToString();
      if (input1 == null)
        return FrameworkMessages.Common_ObjectString.ToString();
      else
        return Assert.ReplaceNullChars(input1);
    }

    public static string ReplaceNullChars(string input)
    {
      if (string.IsNullOrEmpty(input))
        return input;
      List<int> list = new List<int>();
      for (int index = 0; index < input.Length; ++index)
      {
        if ((int) input[index] == 0)
          list.Add(index);
      }
      if (list.Count <= 0)
        return input;
      StringBuilder stringBuilder = new StringBuilder(input.Length + list.Count);
      int startIndex = 0;
      foreach (int num in list)
      {
        stringBuilder.Append(input.Substring(startIndex, num - startIndex));
        stringBuilder.Append("\\0");
        startIndex = num + 1;
      }
      stringBuilder.Append(input.Substring(startIndex));
      return ((object) stringBuilder).ToString();
    }
  }
}
