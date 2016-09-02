using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class AProximityInteractable : MonoBehaviour, IInteractable {
    protected const float _INTERACTION_DISTANCE = 0.7f;
    private Collider _collider;

    /// <summary>
    /// Sets internal Collider reference, always call base.Start()
    /// if you overload this function
    /// </summary>
    public virtual void Start() {
        _collider = GetComponent<Collider>();
    }

    public bool CanInteractWith(GameObject other) {
        return _getCurrentDistance(other.transform.position) < _INTERACTION_DISTANCE;
    }

    private float _getCurrentDistance(Vector3 point) {
        Vector3 diff;

        diff = _collider.ClosestPointOnBounds(point) - point;
        diff.y = 0; // We're only interested in distance on the XZ plane
        return diff.magnitude;
    }

    public abstract void Interact(GameObject source);
}
