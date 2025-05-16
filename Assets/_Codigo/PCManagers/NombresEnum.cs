using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class NombresEnum
{
    public static string GetInspectorName<T>(T enumValue)
    {
        FieldInfo field = typeof(T).GetField(enumValue.ToString());
        InspectorNameAttribute[] attributes = (InspectorNameAttribute[])field.GetCustomAttributes(typeof(InspectorNameAttribute), false);
        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].displayName;
        }
        return enumValue.ToString();
    }

    public static List<string> GetAllInspectorNames<T>() where T : System.Enum
    {
        List<string> names = new List<string>();
        foreach (T value in System.Enum.GetValues(typeof(T)))
        {
            names.Add(GetInspectorName(value));
        }
        return names;
    }
}

