using Ecomsolutions.Core.Enum;
using System;

namespace Ecomsolutions.Core.Helpers
{
    public static class ExtentionMethodsHolder
    {
        /// <summary>
        /// Converts string key into Orientation value
        /// </summary>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public static Orientation ToOrientation(this string orientation)
        {
            orientation = orientation.ToUpper();

            Orientation orientationToReturn = orientation switch
            {
                "N" => Orientation.North,
                "E" => Orientation.East,
                "S" => Orientation.South,
                "W" => Orientation.West,
                _ => throw new InvalidCastException($"There's no orientation defined by {orientation} key")
            };

            return orientationToReturn;
        }
    }
}