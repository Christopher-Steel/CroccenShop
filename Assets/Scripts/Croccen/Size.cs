using UnityEngine;

namespace Croccen {
    // This follows the type-safe-enum pattern
    // I've used it here so that I can limit the
    // range of sizes croccen can be while
    // linking the Vector3 values to the identifiers
    /// <summary>
    /// Croccen sizes. Can be Baby or Adult.
    /// </summary>
    public sealed class Size {
        public readonly string name;
        public readonly Vector3 value;

        public static readonly Size Baby = new Size("Baby", new Vector3(.25f, .25f, .35f));
        public static readonly Size Adult = new Size("Adult", new Vector3(.5f, .5f, .7f));

        private Size(string name, Vector3 value) {
            this.name = name;
            this.value = value;
        }
    }
}
