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
        /// <summary>
        /// Get the length of the long size of the paper, in mm.
        /// </summary>
        internal static int LongSide(this PaperSize paperSize)
        {
            switch (paperSize)
            {
                case PaperSize.A2:
                    return 554;
                case PaperSize.A3:
                    return 420;
                case PaperSize.A4:
                    return 297;
                case PaperSize.Custom:
                default:
                    // Paper size is set explicitly elsewhere.
                    return 0;
            }
        }

        /// <summary>
        /// Get the length of the short side of the paper, in mm.
        /// </summary>
        internal static int ShortSide(this PaperSize paperSize)
        {
            switch (paperSize)
            {
                case PaperSize.A2:
                    return 420;
                case PaperSize.A3:
                    return 297;
                case PaperSize.A4:
                    return 210;
                case PaperSize.Custom:
                default:
                    // Paper size is set explicitly elsewhere.
                    return 0;
            }
        }

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
