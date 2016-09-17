using UnityEngine;

namespace Helpers {
    public class Distance2D {
        public static float Between(GameObject a, GameObject b) {
            Vector3 bPoint;

            bPoint = _calculateMeasuringPoint(b, a.transform.position);
            return Between(a, bPoint);
        }

        public static float Between(GameObject a, Vector3 x) {
            Vector3 diff;
            Vector3 aPoint;

            // if a has a collider, use it as a boundingBox
            // if b has a collider, use it as a boundingBox
            aPoint = _calculateMeasuringPoint(a, x);
            diff = aPoint - x;
            diff.y = 0; // We're only interested in distance on the XZ plane
            return diff.magnitude;
        }

        private static Vector3 _calculateMeasuringPoint(GameObject a, Vector3 x) {
            Collider aCollider = a.GetComponent<Collider>();

            if (aCollider == null)
                return a.transform.position;
            return aCollider.ClosestPointOnBounds(x);
        }
    }
}