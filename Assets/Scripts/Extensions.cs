using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Vector3 test = new Vector3(MathF.Round(v.x / value) * value, MathF.Round(v.y / value) * value, MathF.Round(v.z / value) * value);
        return test;
    }

    public static Vector3 RoundOffTop(this Vector3 v, int value)
    {
        Vector3 test = new Vector3(MathF.Round(v.x / value) * value, (MathF.Round(v.y / value) * value) + value, MathF.Round(v.z / value) * value);
        return test;
    }

    public static Vector3 RoundOffUp(this Vector3 v, int value)
    {
        Vector3 test = new Vector3(v.x, MathF.Round(v.y / value) * value, v.z);
        return test;
    }
}
