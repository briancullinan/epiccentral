using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;

public static class TypeExtensions
{
    public static bool IsLocked(this object o)
    {
        if (!Monitor.TryEnter(o))
            return true;
        Monitor.Exit(o);
        return false;
    }

    /// <summary>
    /// Gets a list of types the specified type extends.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetBaseTypes(this Type type)
    {
        if (type.BaseType != null)
            return new[] { type.BaseType }.Concat(type.BaseType.GetBaseTypes());
        return new Type[] {};
    }

    /// <summary>
    /// Checks is a type extends the current type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="ofType"></param>
    /// <returns></returns>
    public static Type GenericExtendsType(this Type type, Type ofType)
    {
        foreach (Type testType in type.GetBaseTypes())
        {
            if (testType.IsGenericType)
            {
                if (testType.GetGenericTypeDefinition() == ofType)
                {
                    return testType;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Checks if a type implements the current type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="ofType"></param>
    /// <returns></returns>
    public static Type GenericImplementsType(this Type type, Type ofType)
    {
        foreach (Type testType in type.GetInterfaces())
        {
            if (testType.IsGenericType)
            {
                if (testType.GetGenericTypeDefinition() == ofType)
                {
                    return testType;
                }
            }
        }
        return null;
    }

}
