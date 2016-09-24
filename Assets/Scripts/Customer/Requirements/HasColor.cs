using UnityEngine;

namespace Customer.Requirements {
    class HasColor : IRequirement {
        public Croccen.Color targetColor;

        public HasColor(Croccen.Color color) {
            targetColor = color;
        }

        public bool IsMet(GameObject croccen) {
            var properties = croccen.GetComponent<Croccen.Properties>();

            return (properties != null && properties.color == targetColor);
        }
    }
}
