using System;
using System.Collections.Generic;
using System.Linq;

namespace MapProjector
{
    /// <summary>
    /// Static class containing helper functions and extension methods.
    /// </summary>
    internal static class Helpers
    {
        internal static double DegToRad(double deg)
        {
            return (deg * Math.PI) / 180.0;
        }

        internal static double RadToDeg(double rad)
        {
            return (rad * 180.0) / Math.PI;
        }

        internal static Dictionary<TKey, TValue> SortDictionaryByKeyAscending<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            return dict
                .OrderBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        internal static Dictionary<TKey, TValue> SortDictionaryByKeyDescending<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            return dict
                .OrderByDescending(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
