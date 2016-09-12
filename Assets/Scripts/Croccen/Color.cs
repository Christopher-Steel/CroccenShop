using UnityEngine;

namespace Croccen
{
    // This follows the type-safe-enum pattern
    // I've used it here so that I can limit the
    // range of colors croccen can be while
    // linking the Color32 values to the identifiers
    /// <summary>
    /// Croccen colors. Can be Grey, Brown or Green.
    /// </summary>
    public sealed class Color
    {
        public readonly string name;
        public readonly Color32 value;

        public static readonly Color Grey = new Color("Grey", new Color32(57, 72, 77, 255));
        public static readonly Color Brown = new Color("Brown", new Color32(115, 75, 32, 255));
        public static readonly Color Green = new Color("Green", new Color32(100, 140, 74, 255));

        private Color(string name, Color32 value) {
            this.name = name;
            this.value = value;
        }
    }
}
