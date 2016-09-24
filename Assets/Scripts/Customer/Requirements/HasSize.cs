using UnityEngine;

namespace Customer.Requirements {
    class HasSize : IRequirement {
        public Croccen.Size targetSize;

        public HasSize(Croccen.Size size) {
            targetSize = size;
        }

        public bool IsMet(GameObject croccen) {
            var properties = croccen.GetComponent<Croccen.Properties>();

            return (properties != null && properties.size == targetSize);
        }
    }
}
