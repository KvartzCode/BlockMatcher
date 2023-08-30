using System;
using System.Collections.Generic;
using UnityEngine;


public static class Extensions
{
    public static T RemoveAndGet<T>(this IList<T> list, int index)
    {
        lock (list)
        {
            T value = list[index];
            list.RemoveAt(index);
            return value;
        }
    }

    public static Vector3 RoundOff(this Vector3 v, int value)
    {
        return new Vector3(MathF.Round(v.x / value) * value, MathF.Round(v.y / value) * value, MathF.Round(v.z / value) * value);
    }

    public static Vector3 RoundOff(this Vector3 v, float x, float y, float z)
    {
        return new Vector3(MathF.Round(v.x / x) * x, MathF.Round(v.y / y) * y, MathF.Round(v.z / z) * z);
    }

    public static Vector3 RoundOffTop(this Vector3 v, int value)
    {
        return new Vector3(MathF.Round(v.x / value) * value, (MathF.Round(v.y / value) * value) + value, MathF.Round(v.z / value) * value);
    }

    public static Vector3 RoundOffUp(this Vector3 v, int value)
    {
        return new Vector3(v.x, MathF.Round(v.y / value) * value, v.z);
    }
}
