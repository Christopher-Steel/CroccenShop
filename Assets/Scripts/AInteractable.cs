using UnityEngine;

public abstract class AInteractable : MonoBehaviour, IInteractable {
    public float InteractDistance { get; protected set; }

    public AInteractable() {
        InteractDistance = 0.6f;
    }

    public abstract void Interact(GameObject source);
}
